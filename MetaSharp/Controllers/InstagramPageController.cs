using MetaSharp.Entities.Page;
using MetaSharp.Source;
using System.Text.Json;
using System.Text.Json.Nodes;

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
                string endPointUrl = $"/{pageId}/media?access_token={accessToken}&image_url={photoUrl}&is_carousel_item=true";
                var response = await Helpers.ExecutePostRequest<string>(endPointUrl);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                var id = JsonObject.Parse(response)["id"];

                return id == null ? "" : id.ToString();
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
                string endPointUrl = $"/{pageId}/media?access_token={accessToken}&caption={caption}&children={string.Join(',', tempPictureUploadIds)}&media_type=CAROUSEL";
                var response = await Helpers.ExecutePostRequest<string>(endPointUrl);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                var id = JsonObject.Parse(response)["id"];

                return id == null ? "" : id.ToString();
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
                List<string> tempPictureUploadIds = [];
                if (pageFeedRequestContent.PhotoUrls != null && pageFeedRequestContent.PhotoUrls.Any())
                {
                    foreach (var photoUrl in pageFeedRequestContent.PhotoUrls)
                    {
                        tempPictureUploadIds.Add(await UploadImageTempAsync(pageId, photoUrl));
                    }
                }
                string messagesQuery = pageFeedRequestContent.MessageLines != null && pageFeedRequestContent.MessageLines.Any() ? $"{formatMessageString(pageFeedRequestContent.MessageLines)}" : "";
                string containerId = await UploadImageContainerTempAsync(pageId, messagesQuery, tempPictureUploadIds.ToArray());

                string endPointUrl = $"/{pageId}/media_publish?access_token={accessToken}&creation_id={containerId}";
                var response = await Helpers.ExecutePostRequest<string>(endPointUrl);
                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("No content found.");
                }
                return JsonSerializer.Deserialize<CreateFeedResponse>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}