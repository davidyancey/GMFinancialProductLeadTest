using GMFinancialLeadTest.Core;
using System.Net;

namespace GMFinancialLeadTest.IntegrationTests
{
    public class ProductAPIQueryIntegrationTests
    {
        [Test]
        public void ConnectionToAPIShouldReturn200StatusCode()
        {
            var apiUrl = "https://fakestoreapi.com/products";
            var apiManager = new APIManager(apiUrl);

            var response = apiManager.GetResponseAsync().Result;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}