namespace MetaSharp.Source
{
    public static class Helpers
    {
        public static async Task<T> ExecutePostRequest<T>(string endpointUrl)
        {
            return await executePostRequest<T>(endpointUrl, null, null, null, null);
        }
        private static async Task<T> executePostRequest<T>(string endpointUrl, string authenticationHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, endpointUrl, authenticationHeaderValue, contentLanguage, keyValuePayload, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception((new { error = responseContent.DeserializeToObject<object>(), payload = JSONPayload?.DeserializeToObject<object>() }).SerializeToJson());
        }
        public static async Task<T> ExecuteGetRequest<T>(string endpointUrl)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Get, endpointUrl, null, null, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception((new { error = responseContent.DeserializeToObject<object>() }).SerializeToJson());
        }
        private static async Task<HttpResponseMessage> executeRequest(HttpMethod httpMethod, string endpointUrl, string authenticationHeaderValue, string? contentLanguageHeaderValue,
            List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(httpMethod, $"{Constants.GraphAPI.URL}/{Constants.GraphAPI.VERSION}/{endpointUrl}");
            if (authenticationHeaderValue != null)
            {
                request.Headers.Add("Authorization", authenticationHeaderValue);
            }
            if (keyValuePayload != null)
            {
                var content = new FormUrlEncodedContent(keyValuePayload);
                request.Content = content;
            }
            else if (JSONPayload != null)
            {
                var content = new StringContent(JSONPayload, null, "application/json");
                if (string.IsNullOrEmpty(contentLanguageHeaderValue) == false)
                {
                    content.Headers.Add("Content-Language", contentLanguageHeaderValue.Replace("_", "-"));
                }
                request.Content = content;
            }
            var response = await client.SendAsync(request);
            return response;
        }
    }
}
