using GMFinancialLeadTest.ProductDomain;
using GMFinancialLeadTest.Core;
using Newtonsoft.Json;
using Moq;

namespace GMFinancialLeadTest.UnitTests
{
    [TestFixture]
    public class ProductAPIQueryTests
    {
        private Mock<IFileService> fileServiceMock;

        [Test]
        public void APIQueryShouldReturnResults()
        {
            fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(x => x.Write(It.IsAny<string>()));
            
            var apiManager = new FakeAPIManager();
            var productService = new ProductService(apiManager, fileServiceMock.Object);
            
            string content = productService.GetAll().Result;
            List<Product> productList = content == null ? new List<Product>(): JsonConvert.DeserializeObject<IEnumerable<Product>>(content).ToList();
            Assert.That(productList.Any(), Is.True);
        }

        [Test]
        public void APIFilteredQueryShouldReturnResults()
        {
            fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(x => x.Write(It.IsAny<string>()));
            
            var expectedCount = 12;
            var apiManager = new FakeAPIManager();
            var productService = new ProductService(apiManager, fileServiceMock.Object);

            string content = productService.Get(x => x.Rating.Rate >= 3 && x.Rating.Count >= 100).Result;
            List<Product> productList = content == null ? new List<Product>() : JsonConvert.DeserializeObject<IEnumerable<Product>>(content).ToList();

            Assert.That(productList.Count() == expectedCount, string.Format("Expected count of {0} and actual count was {1}", expectedCount, productList.Count()));
        }
    }
}
