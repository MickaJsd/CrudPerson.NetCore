using CrudPerson.WebUI.Controllers;
using CrudPerson.WebUI.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CrudPerson.WebUI
{
    public class Startup
    {
        #region Internal constants
        internal const string CULTURE_EN = "en";
        #endregion

        #region private properties and constants
        private const string CULTURE_FR = "fr";
        private static readonly string[] _supportedCultures = new string[] { CULTURE_EN, CULTURE_FR };
        #endregion

        #region Public properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        #endregion

        #region Public methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddWebUiServices(_supportedCultures)
                        .AddBusinessServices()
                        .AddRepositoryServices(this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            string errorPath = $"/{Actions.Controller<ErrorController>()}";

            if (env.IsDevelopment())
            {
                app.ApplicationServices.ConfigureDataBase(); // database migration in dev mode only
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseExceptionHandler(errorPath)
                    .UseHsts();// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(_supportedCultures[0])
                .AddSupportedCultures(_supportedCultures)
                .AddSupportedUICultures(_supportedCultures);
            const string GUID_REGEX_PATTERN = "[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}";

            _ = app
                .UseRequestLocalization(localizationOptions)
                .UseHttpsRedirection()
                .UseStatusCodePagesWithReExecute(errorPath, "?statusCode={0}")
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    _ = endpoints.MapControllerRoute(
                            name: "default",
                            pattern: $"{{controller={Actions.Controller<HomeController>()}}}/{{action={nameof(HomeController.Index)}}}/{{identifier?}}",
                            constraints: new { identifier = GUID_REGEX_PATTERN }); // allow GUID id type
                });
        }
        #endregion
    }
}
