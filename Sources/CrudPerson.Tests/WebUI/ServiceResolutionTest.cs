using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.DataLibrary.Repositories;
using CrudPerson.Tests.Internal.Mocks;
using CrudPerson.WebUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrudPerson.Tests.WebUI
{
    [TestClass]
    public class ServiceResolutionTest : TestsBase
    {
        #region private Methods

        private static void GenericServiceResolutionTest<TService>()
        {
            // arrange
            IConfiguration mockedConfiguration = MockConfiguration.GetMock();
            Startup pluggedStartup = new Startup(mockedConfiguration);
            IServiceCollection serviceCollection = new ServiceCollection();

            // act
            pluggedStartup.ConfigureServices(serviceCollection);
            //_ = serviceCollection.AddTransient<PersonController>();

            // assert
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            TService service = serviceProvider.GetService<TService>();
            Assert.IsNotNull(service);
        }
        #endregion

        #region Test Methods
        [TestMethod]
        public void PersonManagerServiceResolutionTest()
        {
            GenericServiceResolutionTest<IPersonManager>();
        }

        [TestMethod]
        public void PersonRepositoryServiceResolutionTest()
        {
            GenericServiceResolutionTest<IPersonRepository>();
        }
        #endregion
    }
}
