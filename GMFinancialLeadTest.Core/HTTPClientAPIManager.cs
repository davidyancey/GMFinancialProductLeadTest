namespace GMFinancialLeadTest.Core
{
    /// <summary>
    /// Manages connection to the API through an HTTPClient
    /// </summary>
    public class HTTPClientAPIManager : IAPIManager
    {
        private readonly string url;
        readonly HttpClient httpClient;

        public HTTPClientAPIManager(string url)
        {
            this.url = url;
            httpClient = new HttpClient();
        }
        public async Task<string> GetAPIResults()
        {
            HttpResponseMessage response = await GetResponseAsync();
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<HttpResponseMessage> GetResponseAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            return response;
        }

    }
}
