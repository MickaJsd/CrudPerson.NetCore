using CrudPerson.DataLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace System
{
    public static class IServiceProviderExtensions
    {
        public static void ConfigureDataBase(this IServiceProvider serviceProvider)
        {
            using (IServiceScope serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (IDatabaseContext context = serviceScope.ServiceProvider.GetService<IDatabaseContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
