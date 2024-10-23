using MetaSharp.Entities.Page;
using MetaSharp.Source;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MetaSharp.Controllers
{
    class FacebookPageController
    {
        private string accessToken;
        public FacebookPageController(string longLivedAccessToken)
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
                string url = $"/me/photos?access_token={accessToken}&url={photoUrl}&published=false";
                var response = await Helpers.ExecutePostRequest<string>(url);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                var id = JObject.Parse(response)["id"];
                return id == null ? "" : id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
        public async Task<PageInfo> GetPageDetailsAsync(string pageId)
        {
            string url = $"/{pageId}?access_token={accessToken}&fields={Constants.GraphAPI.Page.Fields.ME}";
            var response = await Helpers.ExecuteGetRequest<string>(url);
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("No content found.");
            }
            return JsonConvert.DeserializeObject<PageInfo>(response);

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
                List<string> tempPictureUploadIds = new();
                if (pageFeedRequestContent.PhotoUrls != null && pageFeedRequestContent.PhotoUrls.Any())
                {
                    foreach (var photoUrl in pageFeedRequestContent.PhotoUrls)
                    {
                        tempPictureUploadIds.Add(await UploadImageTempAsync(photoUrl));
                    }
                }
                string messagesQuery = pageFeedRequestContent.MessageLines != null && pageFeedRequestContent.MessageLines.Any() ? $"&{formatMessageString(pageFeedRequestContent.MessageLines)}" : "";
                string imagesQuery = tempPictureUploadIds.Any() ? "&" + formatImageLinks(tempPictureUploadIds.ToArray()) : "";


                string url = $"/{pageId}/feed?access_token={accessToken}{messagesQuery}{imagesQuery}";
                var response = await Helpers.ExecutePostRequest<string>(url);

                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                return JsonConvert.DeserializeObject<CreateFeedResponse>(response);
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
                
                string messagesQuery = messageLines != null && messageLines.Any() ? $"&{formatMessageString(messageLines)}" : "";
                string linkQuery = string.IsNullOrEmpty(linkToNavigate) == false ? $"&link={linkToNavigate}" : "";
                string requestUrl = $"/{pageId}/feed?access_token={accessToken}{messagesQuery}{linkQuery}";

                var response = await Helpers.ExecutePostRequest<string>(requestUrl);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                return JsonConvert.DeserializeObject<CreateFeedResponse>(response);
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
                string requestUrl = $"/{pageId}/albums?access_token={accessToken}{formatFieldsString(fields)}";
                var response = await Helpers.ExecuteGetRequest<string>(requestUrl);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                return JObject.Parse(response);
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
                string requestUrl = $"/{pageId}/conversations?access_token={accessToken}{formatFieldsString(fields)}";
                var response = await Helpers.ExecuteGetRequest<string>(requestUrl);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                return JObject.Parse(response);
            }
            catch (Exception ex)
            {
                return new JObject(new { message = ex.Message });
            }
        }
    }
}