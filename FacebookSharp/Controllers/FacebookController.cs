using FacebookSharp.Entities;
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
                var options = new RestClientOptions(Constants.GRAPH_API_URL)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
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
        /// <summary>
        /// Gets page detail information
        /// </summary>
        /// <param name="pageId">Page Id</param>
        /// <param name="fields">Comma separated list of fields you want to retrieve</param>
        /// <returns></returns>
        public async Task<JObject> GetPageDetailsAsync(string pageId, string fields = "")
        {
            return await new PageController(accessToken).GetPageDetailsAsync(pageId, fields);
        }
        /// <summary>
        /// Post a feed on a page
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <param name="pageFeedRequestContent">Object containing feed data</param>
        /// <returns></returns>
        public async Task<JObject> PostFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            return await new PageController(accessToken).PostFeedAsync(pageId, pageFeedRequestContent);
        }
    }
}
