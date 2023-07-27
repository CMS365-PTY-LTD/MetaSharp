namespace FacebookSharp.Entities
{
    public class PageFeedRequestContent
    {
        public IEnumerable<string>? PhotoUrls { get; set; }
        public IEnumerable<string>? MessageLines { get; set; }
    }
}
