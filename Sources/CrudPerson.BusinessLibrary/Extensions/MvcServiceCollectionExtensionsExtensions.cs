using CrudPerson.BusinessLibrary.Internal.Managers;
using CrudPerson.BusinessLibrary.Internal.ViewModels;
using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.BusinessLibrary.ViewModels;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensionsExtensions
    {
        /// <summary>
        /// Add the <see cref="IPersonManager"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonManager"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddScopedPersonManager(this IServiceCollection services)
        {
            return services.AddScoped<IPersonManager, PersonManager>();
        }

        /// <summary>
        /// Add the mocked <see cref="IPersonManager"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="IPersonManager"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddSingletonMockedPersonManager(this IServiceCollection services)
        {
            return services.AddSingleton<IPersonManager, MockedPersonManager>();
        }
    }
}
