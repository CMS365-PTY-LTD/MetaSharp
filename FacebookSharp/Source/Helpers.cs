using RestSharp;

namespace FacebookSharp.Source
{
    public static class Helpers
    {
        public static RestClient GetRestClient()
        {
            var options = new RestClientOptions($"{Constants.GraphAPI.URL}/{Constants.GraphAPI.VERSION}")
            {
                MaxTimeout = -1,
            };
            return new RestClient(options);
        }
    }
}
