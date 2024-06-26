using RestSharp;

namespace MetaSharp.Source
{
    public static class Helpers
    {
        public static RestClient GetRestClient()
        {
            var options = new RestClientOptions($"{Constants.GraphAPI.URL}/{Constants.GraphAPI.VERSION}")
            {
                Timeout = TimeSpan.FromMilliseconds(-1),
            };
            return new RestClient(options);
        }
    }
}
