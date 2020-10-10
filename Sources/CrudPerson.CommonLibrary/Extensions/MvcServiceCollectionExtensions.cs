using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        /// <summary>
        /// Add the <see cref="TImplementation"/> service to the specified <see cref="IServiceCollection"/> with the specified lifetime.
        /// </summary>
        /// <typeparam name="TService">Service interface</typeparam>
        /// <typeparam name="TImplementation">Concrete implementation of the <see cref="TService"/> inteface</typeparam>
        /// <param name="services"><see cref="IServiceCollection"/> to add the new service to</param>
        /// <param name="lifetime">lifetime of the new instances created from the service collection by the dependency injection engine</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddService<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
               where TService : class
               where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            ServiceDescriptor item = new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime);
            services.Add(item);
            return services;
        }
    }
}
