using MetaSharp.Entities.Page;
using MetaSharp.Source;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MetaSharp.Controllers
{
    class PageController
    {
        private string accessToken;
        public PageController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }

        #region PRIVATE_METHODS

        private string formatImageLinks(IEnumerable<string> imageIds)
        {
            var formattedStringArray = imageIds.Select((r, i) => "attached_media[" + i + "]={\"media_fbid\":\"" + r + "\"}");
            return string.Join("&", formattedStringArray);
        }
        private string formatMessageString(IEnumerable<string> messageLines)
        {
            return $"message={string.Join("%0A", messageLines)}";
        }
        private string formatFieldsString(string fields)
        {
            return string.IsNullOrEmpty(fields) ? "" : $"&fields={fields}";
        }
        private async Task<string> UploadImageTempAsync(string photoUrl)
        {
            try
            {
                var client = Helpers.GetRestClient();
                var request = new RestRequest($"/me/photos?access_token={accessToken}&url={photoUrl}&published=false", Method.Post);
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
        public async Task<PageInfo> GetPageDetailsAsync(string pageId)
        {
            var client = Helpers.GetRestClient();
            string requestUrl = $"/{pageId}?access_token={accessToken}&fields={Constants.GraphAPI.Page.Fields.ME}";
            var request = new RestRequest(requestUrl, Method.Get);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                if (string.IsNullOrEmpty(response.Content))
                {
                    throw new Exception("No content found.");
                }
                return JsonConvert.DeserializeObject<PageInfo>(response.Content);
            }
            throw new Exception($"Error, {response.Content}");
        }
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
                        tempPictureUploadIds.Add(await UploadImageTempAsync(photoUrl));
                    }
                }
                var client = Helpers.GetRestClient();
                string messagesQuery = pageFeedRequestContent.MessageLines != null && pageFeedRequestContent.MessageLines.Any() ? $"&{formatMessageString(pageFeedRequestContent.MessageLines)}" : "";
                string imagesQuery = tempPictureUploadIds.Any() ? "&" + formatImageLinks(tempPictureUploadIds.ToArray()) : "";
                var request = new RestRequest($"/{pageId}/feed?access_token={accessToken}{messagesQuery}{imagesQuery}", Method.Post);
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
        public async Task<CreateFeedResponse> PostFeedAsync(string pageId, IEnumerable<string> messageLines, string linkToNavigate)
        {
            try
            {
                if ((messageLines==null|| messageLines.Any()==false) && string.IsNullOrEmpty(linkToNavigate))
                {
                    throw new Exception("You must pass some content to post.");
                }
                var client = Helpers.GetRestClient();
                string messagesQuery = messageLines != null && messageLines.Any() ? $"&{formatMessageString(messageLines)}" : "";
                string linkQuery = string.IsNullOrEmpty(linkToNavigate) == false ? $"&link={linkToNavigate}" : "";
                string requestUrl = $"/{pageId}/feed?access_token={accessToken}{messagesQuery}{linkQuery}";
                var request = new RestRequest(requestUrl, Method.Post);
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
        public async Task<JObject> GetPageAlbumsAsync(string pageId, string fields)
        {
            try
            {
                var client = Helpers.GetRestClient();
                string requestUrl = $"/{pageId}/albums?access_token={accessToken}{formatFieldsString(fields)}";
                var request = new RestRequest(requestUrl, Method.Get);
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
        public async Task<JObject> GetPageConversations(string pageId, string fields)
        {
            try
            {
                var client = Helpers.GetRestClient();
                string requestUrl = $"/{pageId}/conversations?access_token={accessToken}{formatFieldsString(fields)}";
                var request = new RestRequest(requestUrl, Method.Get);
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
    }
}