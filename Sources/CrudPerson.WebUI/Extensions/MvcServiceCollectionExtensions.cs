using AutoMapper;
using CrudPerson.CommonLibrary.Exceptions;
using CrudPerson.CommonLibrary.Resources;
using CrudPerson.WebUI.Internal.Configuration;
using CrudPerson.WebUI.Internal.Models;
using CrudPerson.WebUI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        #region Constants
        const string RESOURCE_PATH = "Resources";
        #endregion

        #region Private methods
        private static IList<CultureInfo> GetSupportedCultures(string[] supportedCultures)
        {
            return supportedCultures.Select(s => new CultureInfo(s)).ToList();
        }

        private static IServiceCollection ConfigureWebUiServices(this IServiceCollection services, string[] supportedCultures)
        {
            if (supportedCultures?.Any() != true)
            {
                throw new System.Exception("Missing supported culture");
            }
            IList<CultureInfo> SupportedCultures = GetSupportedCultures(supportedCultures);
            return services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
                options.SupportedCultures = SupportedCultures;
                options.SupportedUICultures = SupportedCultures;
            });
        }
        #endregion

        /// <summary>
        /// Add the <see cref="CrudPerson.WebUI"/> service to the specified <see cref="IServiceCollection"/> with a <see cref="ServiceLifetime.Scoped"/> lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the <see cref="CrudPerson.WebUI"/> service to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained</returns>
        public static IServiceCollection AddWebUiServices(this IServiceCollection services, string[] supportedCultures)
        {
            _ = services.AddControllersWithViews();
            _ = services.AddMvc()
                        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                        .AddDataAnnotationsLocalization();
            return services.AddScoped<IPersonModel, PersonModel>()
                           .AddAutoMapper(typeof(ViewModelAsBusinessMapping))
                           .AddLocalization(options => options.ResourcesPath = RESOURCE_PATH)
                           .ConfigureWebUiServices(supportedCultures);
        }
    }
}
