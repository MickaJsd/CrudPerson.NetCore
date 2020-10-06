using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Resources;

[assembly: NeutralResourcesLanguage(CrudPerson.WebUI.Startup.CULTURE_EN)]
namespace CrudPerson.WebUI
{
    public class Startup
    {
        #region private properties
        const string CULTURE_FR = "fr";
        internal const string CULTURE_EN = "en";
        private static string[] _supportedCultures = new string[] { CULTURE_EN, CULTURE_FR};
        #endregion
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseExceptionHandler("/Home/Error")
                    .UseHsts();// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(_supportedCultures[0])
                .AddSupportedCultures(_supportedCultures)
                .AddSupportedUICultures(_supportedCultures);

            _ = app
                .UseRequestLocalization(localizationOptions)
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    _ = endpoints.MapControllerRoute(
                            name: "guidId",
                            pattern: "{controller=Home}/{action=Index}/{identifier?}",
                            constraints: new { identifier = "[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}" }); // allow GUID id type
                })
                .UseEndpoints(endpoints =>
                {
                    _ = endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
