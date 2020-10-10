using CrudPerson.DataLibrary.Data;
using CrudPerson.Tests.Internal.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrudPerson.Tests
{
    [TestClass]
    public static class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {

            IConfiguration mockedConfiguration = Configuration.GetMock();
            ServiceProvider serviceProvider = new ServiceCollection()
                                        .AddBusinessServices()
                                        .AddRepositoryServices(mockedConfiguration)
                                        .BuildServiceProvider();

            // création d'une base de données de test
            // nécessite d'être vidée après les tests : regarder du côté de EfCore/InMemory/Sqlite

            using (IServiceScope serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (IDatabaseContext dbcontext = serviceScope.ServiceProvider.GetService<IDatabaseContext>())
                {
                    dbcontext.Database.Migrate();
                }
            }
            context.Properties.Add("ServiceProvider", serviceProvider);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // effectuer un drop de la base de donnée de test
        }
    }
}
