
using MetaSharp.Entities.Page;

namespace MetaSharp.Controllers
{
    public class InstragramController
    {
        private string accessToken;
        public InstragramController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }

        #region PAGE

        /// <summary>
        /// Post a feed on a page
        /// </summary>
        /// <param name="pageId">Page id</param>
        /// <param name="pageFeedRequestContent">Object containing feed data</param>
        /// <returns>CreateFeedResponse object</returns>
        public async Task<CreateFeedResponse> PostPageFeedAsync(string pageId, PageFeedRequestContent pageFeedRequestContent)
        {
            return await new InstagramPageController(accessToken).PostFeedAsync(pageId, pageFeedRequestContent);
        }

        #endregion
    }
}
