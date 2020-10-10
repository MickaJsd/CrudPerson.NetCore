using AutoMapper;
using CrudPerson.BusinessLibrary.Internal.Configuration;
using CrudPerson.BusinessLibrary.Internal.Managers;
using CrudPerson.BusinessLibrary.Managers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        #region Private Methods
        private static IServiceCollection InnerAddBusinessServices<TImplementation>(this IServiceCollection services, ServiceLifetime businessServiceLifetime)
           where TImplementation : class, IPersonManager
        {
            return services.AddService<IPersonManager, TImplementation>(businessServiceLifetime)
                           .AddAutoMapper(typeof(BusinessAsDataMapping));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add the <see cref="CrudPerson.BusinessLibrary"/> services to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="CrudPerson.BusinessLibrary"/> services to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.InnerAddBusinessServices<PersonManager>(ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Add the mocked <see cref="IPersonManager"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Singleton"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonManager"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddMockedBusinessServices(this IServiceCollection services, ServiceLifetime businessServiceLifetime)
        {
            return services.InnerAddBusinessServices<MockedPersonManager>(businessServiceLifetime);
        }
        #endregion
    }
}
