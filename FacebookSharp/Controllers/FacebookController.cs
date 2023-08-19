using FacebookSharp.Entities.Page;
using FacebookSharp.Source;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FacebookSharp.Controllers
{
    public class FacebookController
    {
        private string accessToken;
        public FacebookController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }
        public async Task<JObject> Get(string endpointUrl)
        {
            try
            {
                var client = Helpers.GetRestClient();
                var request = new RestRequest($"{endpointUrl}&access_token={accessToken}", Method.Get);
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    if (string.IsNullOrEmpty(response.Content))
                    {
                        throw new Exception("No content found.");
                    }
                    return JObject.Parse(response.Content);
                }
                throw new Exception($"Error, {response.Content}");
            }
            catch (Exception ex)
            {
                return new JObject(new { message = ex.Message });
            }
        }

        #region PAGE

        /// <summary>
        /// Gets page detail information
        /// </summary>
        /// <param name="pageId">Page Id</param>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        /// <returns>PageInfo object</returns>
        public async Task<PageInfo> GetPageDetailsAsync(string pageId)
        {
            return await new PageController(accessToken).GetPageDetailsAsync(pageId);
        }
        /// <summary>
        /// Post a feed on a page
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <param name="pageFeedRequestContent">Object containing feed data</param>
        /// <returns>CreateFeedResponse object</returns>
        public async Task<CreateFeedResponse> PostPageFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            return await new PageController(accessToken).PostFeedAsync(pageId, pageFeedRequestContent);
        }
        /// <summary>
        /// Post a feed on a page
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <param name="messageLines">string array of lines</param>
        /// <param name="linkToNavigate">A link to navigate</param>
        /// <returns>CreateFeedResponse object</returns>
        public async Task<CreateFeedResponse> PostPageFeedAsync(string pageId, IEnumerable<string> messageLines, string linkToNavigate)
        {
            return await new PageController(accessToken).PostFeedAsync(pageId, messageLines, linkToNavigate);
        }
        /// <summary>
        /// Get page albums
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <returns>Albums list JSON object</returns>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        public async Task<JObject> GetPageAlbumsAsync(string pageId, string fields = "")
        {
            return await new PageController(accessToken).GetPageAlbumsAsync(pageId, fields);
        }
        /// <summary>
        /// Get page conversations
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <returns>Conversation list JSON object</returns>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        public async Task<JObject> GetPageConversations(string pageId, string fields = "")
        {
            return await new PageController(accessToken).GetPageConversations(pageId, fields);
        }

        #endregion
    }
}
