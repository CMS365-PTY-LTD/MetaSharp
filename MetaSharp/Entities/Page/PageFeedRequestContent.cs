namespace MetaSharp.Entities.Page
{
    public class PageFeedRequestContent
    {
        public IEnumerable<string> PhotoUrls { get; set; }
        public IEnumerable<string> MessageLines { get; set; }
    }
}
