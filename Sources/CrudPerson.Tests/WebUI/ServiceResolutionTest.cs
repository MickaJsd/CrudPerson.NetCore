using CrudPerson.BusinessLibrary.Managers;
using CrudPerson.DataLibrary.Repositories;
using CrudPerson.Tests.Internal.Mocks;
using CrudPerson.WebUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;

namespace CrudPerson.Tests.WebUI
{
    [TestClass]
    public class ServiceResolutionTest
    {
        #region private Methods

        private void GenericServiceResolutionTest<TService>()
        {
            // arrange
            IConfiguration mockedConfiguration = Configuration.GetMock();
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
            this.GenericServiceResolutionTest<IPersonManager>();
        }

        [TestMethod]
        public void PersonRepositoryServiceResolutionTest()
        {
            this.GenericServiceResolutionTest<IPersonRepository>();
        }
        #endregion
    }
}
