using System.Text.Json.Serialization;

namespace MetaSharp.Entities.Page
{
    public class CreateFeedResponse
    {
        public string Id { get; set; }
        [JsonPropertyName("post_supports_client_mutation_id")]
        public bool PostSupportsClientMutitionId { get; set; }
    }
}
