using CrudPerson.DataLibrary.Internal.Repositories;
using CrudPerson.DataLibrary.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        /// <summary>
        /// Add the <see cref="IPersonRepository"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonRepository"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            return services.AddScoped<IPersonRepository, PersonRepository>();
        }

        /// <summary>
        /// Add the mocked <see cref="IPersonManager"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Singleton"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonRepository"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddMockedRepositoryServices(this IServiceCollection services)
        {
            return services.AddSingleton<IPersonRepository, MockedPersonRepository>();
        }
    }
}
