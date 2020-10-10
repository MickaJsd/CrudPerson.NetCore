using CrudPerson.DataLibrary.Data;
using CrudPerson.DataLibrary.Internal.Data;
using CrudPerson.DataLibrary.Internal.Repositories;
using CrudPerson.DataLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        #region Private constants
        private const string CONFIGURATION_NULL_EXCEPTION = "Configuration is required to add all the services";
        private const string CONFIGURATION_UNKOWN_DATABASE_TYPE_EXCEPTION = "The configured database type is unknown.";
        private const string CONFIGURATION_MISSING_DATABASE_TYPE_EXCEPTION = "The database type is missing or empty in configuration";
        private const string CONFIGURATION_MISSING_CONNECTION_STRING_EXCEPTION = "The database connectionstring is missing or empty in configuration";
        private const string CONNECTION_STRING_NAME = "CrudPerson";
        private const string DATABASE_TYPE_PARAMETER_NAME = "dbtype";
        #endregion

        #region Private methods
        private static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder options, string dbType, string connectionstring)
        {
            if (Enum.TryParse(dbType, out SupportedDatabaseType enumDbtype))
            {
                switch (enumDbtype)
                {
                    case SupportedDatabaseType.sqlserver:
                        return options.UseSqlServer(connectionstring);
                    case SupportedDatabaseType.postgres:
                        return options.UseNpgsql(connectionstring);
                    case SupportedDatabaseType.unknown:
                    default:
                        break;
                }
            }
            throw new ArgumentException($"{CONFIGURATION_UNKOWN_DATABASE_TYPE_EXCEPTION} : '{dbType}'");
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string dbType = configuration.GetValue<string>(DATABASE_TYPE_PARAMETER_NAME);
            if (string.IsNullOrWhiteSpace(dbType))
            {
                throw new ArgumentException($"{CONFIGURATION_MISSING_DATABASE_TYPE_EXCEPTION}; {DATABASE_TYPE_PARAMETER_NAME}");
            }

            string connectionString = configuration.GetConnectionString(CONNECTION_STRING_NAME);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{CONFIGURATION_MISSING_CONNECTION_STRING_EXCEPTION}; {CONNECTION_STRING_NAME}");
            }

            return services.AddDbContext<DatabaseContext>(options => options.UseDatabase(dbType, connectionString));
        }

        #endregion

        #region Public enums
        public enum SupportedDatabaseType
        {
            unknown,
            sqlserver,
            postgres
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add the <see cref="CrudPerson.DataLibrary"/> services to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="CrudPerson.DataLibrary"/> services to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), CONFIGURATION_NULL_EXCEPTION);
            }

            return services.AddScoped<IPersonRepository, PersonRepository>()
                           .AddScoped<IDatabaseContext, DatabaseContext>()
                           .AddDbContext(configuration);
        }

        /// <summary>
        /// Add the mocked <see cref="IPersonRepository"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Singleton"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonRepository"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        [Obsolete("Do not use - Used at dev time to mock the Business layer")]
        public static IServiceCollection AddMockedRepositoryServices(this IServiceCollection services)
        {
            return services.AddService<IPersonRepository, MockedPersonRepository>(ServiceLifetime.Singleton);
        }
        #endregion
    }
}
