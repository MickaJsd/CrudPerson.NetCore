using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrudPerson.Tests
{
    public class TestsBase
    {
        internal ServiceProvider ServiceProvider => (ServiceProvider)(this.TestContext.Properties["ServiceProvider"] ?? throw new System.Exception("The ServiceProvider isn't initialized"));

        public TestContext TestContext { get; set; }

    }
}
