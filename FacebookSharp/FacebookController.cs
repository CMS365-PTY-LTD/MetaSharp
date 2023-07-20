using FacebookSharp.Controllers;
using FacebookSharp.Entities;
using Newtonsoft.Json.Linq;

namespace FacebookSharp
{
    public class FacebookController
    {
        private string accessToken;
        public FacebookController(string longLivedAccessToken)
        {
            this.accessToken = longLivedAccessToken;
        }
        public async Task<JObject> GetPageDetailsAsync(string pageId)
        {
            return await new PageController(this.accessToken).GetPageDetailsAsync(pageId);
        }
        public async Task<JObject> PostFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            return await new PageController(this.accessToken).PostFeedAsync(pageId, pageFeedRequestContent);
        }
    }
}
