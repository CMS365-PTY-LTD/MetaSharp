using Newtonsoft.Json;

namespace FacebookSharp.Entities.Page
{
    public class CreateFeedResponse
    {
        public string Id { get; set; }
        [JsonProperty("post_supports_client_mutation_id")]
        public bool PostSupportsClientMutitionId { get; set; }
    }
}
