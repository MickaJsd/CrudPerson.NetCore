using CrudPerson.Tests.Internal.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrudPerson.Tests
{
    [TestClass]
    public static class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            IConfiguration mockedConfiguration = MockConfiguration.GetMock();
            ServiceProvider serviceProvider = new ServiceCollection()
                                        .AddBusinessServices()
                                        .AddRepositoryServices(mockedConfiguration)
                                        .BuildServiceProvider();

            // création d'une base de données de test
            // TODO : nécessite d'être vidée après les tests : regarder du côté de EfCore/InMemory/Sqlite

            serviceProvider.ConfigureDataBase();

            context.Properties.Add("ServiceProvider", serviceProvider);
            context.Properties.Add("MockedConfiguration", mockedConfiguration);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // TODO : effectuer un drop de la base de donnée de test
        }
    }
}
