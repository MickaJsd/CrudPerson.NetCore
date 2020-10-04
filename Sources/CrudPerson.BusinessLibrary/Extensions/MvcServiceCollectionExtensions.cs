using CrudPerson.BusinessLibrary.Internal.Managers;
using CrudPerson.BusinessLibrary.Managers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        /// <summary>
        /// Add the <see cref="IPersonManager"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonManager"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddScoped<IPersonManager, PersonManager>();
        }

        /// <summary>
        /// Add the mocked <see cref="IPersonManager"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonManager"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddMockedBusinessServices(this IServiceCollection services)
        {
            return services.AddSingleton<IPersonManager, MockedPersonManager>();
        }
    }
}
