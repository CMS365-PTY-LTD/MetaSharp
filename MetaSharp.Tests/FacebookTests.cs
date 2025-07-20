using MetaSharp.Controllers;
using MetaSharp.Entities.Page;
using Microsoft.Extensions.Configuration;

namespace MetaSharp.Tests
{
    public class FacebookTests
    {
        private FacebookController facebookController;
        private IConfiguration Configuration { get; }

        public FacebookTests()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddUserSecrets<FacebookTests>();
            Configuration = builder.Build();
        }
        [SetUp]
        public void Setup()
        {
            facebookController = new(Configuration["metaAccessToken"]);
        }

        [Test]
        public async Task Test1()
        {
            try
            {
                PageInfo pageInfo = await facebookController.GetPageDetailsAsync(Configuration["pageId"]);
                Assert.That(pageInfo != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
