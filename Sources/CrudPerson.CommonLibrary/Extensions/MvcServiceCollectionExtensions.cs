namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        public static IServiceCollection AddService<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
               where TService : class
               where TImplementation : class, TService
        {

            ServiceDescriptor item = new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime);
            services.Add(item);
            return services;
        }
    }
}
