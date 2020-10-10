using Microsoft.Extensions.Configuration;
using Moq;

namespace CrudPerson.Tests.Internal.Mocks
{
    public static class Configuration
    {
        public static IConfiguration GetMock()
        {
            const string TEST_CONNECTIONSTRING = "User ID=postgres;Password=p@ssw0rd;Host=localhost;Port=5432;Database=CrudPersonTest;";
            const string TEST_DBTYPE = "postgres";

            Mock<IConfigurationSection> configurationSectionConnectionString = new Mock<IConfigurationSection>();
            _ = configurationSectionConnectionString.Setup(x => x["CrudPerson"]).Returns(TEST_CONNECTIONSTRING);
            Mock<IConfigurationSection> configurationSectionDbType = new Mock<IConfigurationSection>();
            _ = configurationSectionDbType.SetupGet(x => x.Value).Returns(TEST_DBTYPE);
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();
            _ = configurationMock.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionConnectionString.Object);
            _ = configurationMock.Setup(x => x.GetSection("dbtype")).Returns(configurationSectionDbType.Object);

            return configurationMock.Object;
        }
    }
}
