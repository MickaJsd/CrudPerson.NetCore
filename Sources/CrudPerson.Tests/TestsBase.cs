using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrudPerson.Tests
{
    public class TestsBase
    {
        internal ServiceProvider ServiceProvider => (ServiceProvider)(this.TestContext.Properties["ServiceProvider"] ?? throw new System.Exception("The ServiceProvider isn't initialized"));
        internal IConfiguration MockedConfiguration => (IConfiguration)(this.TestContext.Properties["MockedConfiguration"] ?? throw new System.Exception("The MockedConfiguration isn't initialized"));

        public TestContext TestContext { get; set; }

    }
}
