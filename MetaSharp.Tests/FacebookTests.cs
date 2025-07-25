﻿using MetaSharp.Controllers;
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
            var builder = new ConfigurationBuilder().AddUserSecrets<FacebookTests>().AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        [SetUp]
        public void Setup()
        {
            facebookController = new(Configuration["META_ACCESSTOKEN"]);
        }
        [Test]
        public async Task TestPage()
        {
            try
            {
                PageInfo pageInfo = await facebookController.GetPageDetailsAsync(Configuration["PAGE_ID"]);
                Assert.That(pageInfo != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
