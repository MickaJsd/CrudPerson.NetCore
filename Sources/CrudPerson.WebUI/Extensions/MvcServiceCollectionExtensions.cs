using AutoMapper;
using CrudPerson.WebUI.Internal.Configuration;
using CrudPerson.WebUI.Internal.Models;
using CrudPerson.WebUI.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        /// <summary>
        /// Add the <see cref="CrudPerson.WebUI"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="CrudPerson.WebUI"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            return services.AddScoped<IPersonModel, PersonModel>()
                           .AddAutoMapper(typeof(ViewModelAsBusinessMapping));
        }
    }
}
