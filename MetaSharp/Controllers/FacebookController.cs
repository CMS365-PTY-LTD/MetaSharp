using MetaSharp.Entities.Page;
using MetaSharp.Source;
using System.Text.Json.Nodes;

namespace MetaSharp.Controllers
{
    public class FacebookController
    {
        private string accessToken;
        public FacebookController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }
        public async Task<JsonObject> Get(string endpointUrl)
        {
            try
            {
                string url = $"{endpointUrl}&access_token={accessToken}";
                var response = await Helpers.ExecuteGetRequest<string>(url);
                
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                return JsonNode.Parse(response).AsObject();
            }
            catch (Exception ex)
            {
                return new JsonObject { ["message"]= ex.Message };
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
            return await new FacebookPageController(accessToken).GetPageDetailsAsync(pageId);
        }
        /// <summary>
        /// Post a feed on a page
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <param name="pageFeedRequestContent">Object containing feed data</param>
        /// <returns>CreateFeedResponse object</returns>
        public async Task<CreateFeedResponse> PostPageFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            return await new FacebookPageController(accessToken).PostFeedAsync(pageId, pageFeedRequestContent);
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
            return await new FacebookPageController(accessToken).PostFeedAsync(pageId, messageLines, linkToNavigate);
        }
        /// <summary>
        /// Get page albums
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <returns>Albums list JSON object</returns>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        public async Task<JsonObject> GetPageAlbumsAsync(string pageId, string fields = "")
        {
            return await new FacebookPageController(accessToken).GetPageAlbumsAsync(pageId, fields);
        }
        /// <summary>
        /// Get page conversations
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <returns>Conversation list JSON object</returns>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        public async Task<JsonObject> GetPageConversations(string pageId, string fields = "")
        {
            return await new FacebookPageController(accessToken).GetPageConversations(pageId, fields);
        }

        #endregion
    }
}
