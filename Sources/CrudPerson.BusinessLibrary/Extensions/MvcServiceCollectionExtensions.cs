using AutoMapper;
using CrudPerson.BusinessLibrary.Internal.Configuration;
using CrudPerson.BusinessLibrary.Internal.Managers;
using CrudPerson.BusinessLibrary.Managers;
using System;

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
        /// <param name="businessServiceLifetime"></param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        [Obsolete("Do not use - Used at dev time to mock the Business layer")]
        public static IServiceCollection AddMockedBusinessServices(this IServiceCollection services)
        {
            return services.InnerAddBusinessServices<MockedPersonManager>(ServiceLifetime.Singleton);
        }
        #endregion
    }
}
