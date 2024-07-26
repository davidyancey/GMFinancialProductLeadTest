using GMFinancialLeadTest.Core;
using System.Net;

namespace GMFinancialLeadTest.IntegrationTests
{
    public class ProductAPIQueryIntegrationTests
    {
        /// <summary>
        /// Integration tests only asserts the ability to connect to the third party API
        /// </summary>
        [Test]
        public void ConnectionToAPIShouldReturn200StatusCode()
        {
            var apiUrl = "https://fakestoreapi.com/products";
            var apiManager = new HTTPClientAPIManager(apiUrl);

            var response = apiManager.GetResponseAsync().Result;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}