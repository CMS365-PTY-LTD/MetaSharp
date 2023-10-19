using MetaSharp.Entities.Page;
using MetaSharp.Source;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MetaSharp.Controllers
{
    class InstagramPageController
    {
        private string accessToken;
        public InstagramPageController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }

        #region PRIVATE_METHODS
        private string formatMessageString(IEnumerable<string> messageLines)
        {
            return $"{string.Join("%0A", messageLines)}";
        }
        private async Task<string> UploadImageTempAsync(string pageId, string photoUrl)
        {
            try
            {
                var client = Helpers.GetRestClient();
                string endPointUrl = $"/{pageId}/media?access_token={accessToken}&image_url={photoUrl}&is_carousel_item=true";
                var request = new RestRequest(endPointUrl, Method.Post);
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    if (string.IsNullOrEmpty(response.Content))
                    {
                        throw new Exception("No content found.");
                    }
                    var id = JObject.Parse(response.Content)["id"];

                    return id == null ? "" : id.ToString();
                }
                throw new Exception($"Error, {response.Content}");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private async Task<string> UploadImageContainerTempAsync(string pageId, string caption, string[] tempPictureUploadIds)
        {
            try
            {
                var client = Helpers.GetRestClient();
                string endPointUrl = $"/{pageId}/media?access_token={accessToken}&caption={caption}&children={string.Join(',', tempPictureUploadIds)}&media_type=CAROUSEL";
                var request = new RestRequest(endPointUrl, Method.Post);
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    if (string.IsNullOrEmpty(response.Content))
                    {
                        throw new Exception("No content found.");
                    }
                    var id = JObject.Parse(response.Content)["id"];

                    return id == null ? "" : id.ToString();
                }
                throw new Exception($"Error, {response.Content}");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
        public async Task<CreateFeedResponse> PostFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            try
            {
                if (pageFeedRequestContent == null ||
                    ((pageFeedRequestContent.PhotoUrls == null || pageFeedRequestContent.PhotoUrls.Any() == false) && (pageFeedRequestContent.MessageLines == null || pageFeedRequestContent.MessageLines.Any() == false)))
                {
                    throw new Exception("You must pass some content to post.");
                }
                List<string> tempPictureUploadIds = new List<string>();
                if (pageFeedRequestContent.PhotoUrls != null && pageFeedRequestContent.PhotoUrls.Any())
                {
                    foreach (var photoUrl in pageFeedRequestContent.PhotoUrls)
                    {
                        tempPictureUploadIds.Add(await UploadImageTempAsync(pageId, photoUrl));
                    }
                }
                string messagesQuery = pageFeedRequestContent.MessageLines != null && pageFeedRequestContent.MessageLines.Any() ? $"{formatMessageString(pageFeedRequestContent.MessageLines)}" : "";
                string containerId = await UploadImageContainerTempAsync(pageId, messagesQuery, tempPictureUploadIds.ToArray());
                var client = Helpers.GetRestClient();
                var request = new RestRequest($"/{pageId}/media_publish?access_token={accessToken}&creation_id={containerId}", Method.Post);
                var response = await client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    if (string.IsNullOrEmpty(response.Content))
                    {
                        throw new Exception("No content found.");
                    }
                    return JsonConvert.DeserializeObject<CreateFeedResponse>(response.Content);
                }
                throw new Exception($"Error, {response.Content}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}