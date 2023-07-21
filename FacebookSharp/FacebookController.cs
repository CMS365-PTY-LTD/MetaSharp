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
        /// <summary>
        /// Gets page detail information
        /// </summary>
        /// <param name="pageId">Page Id</param>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        /// <returns></returns>
        public async Task<JObject> GetPageDetailsAsync(string pageId, string fields = "")
        {
            return await new PageController(this.accessToken).GetPageDetailsAsync(pageId, fields);
        }
        public async Task<JObject> PostFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            return await new PageController(this.accessToken).PostFeedAsync(pageId, pageFeedRequestContent);
        }
    }
}
