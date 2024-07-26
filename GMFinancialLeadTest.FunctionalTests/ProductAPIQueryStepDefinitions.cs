using GMFinancialLeadTest.Core;
using GMFinancialLeadTest.ProductDomain;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;

namespace GMFinancialLeadTest.FunctionalTests
{
    [Binding]
    public class ProductAPIQueryStepDefinitions
    {
        private APIManager apiManager;
        private ProductService productService;
        private FileService fileService;
        private string results;
        private string filteredResults;
        private string fileName = "products.json";
        private string filePath = "c:\\productService\\";

        [Given(@"All products are requested")]
        public void GivenAllProductsAreRequested()
        {
            var apiUrl = "https://fakestoreapi.com/products";
            apiManager = new APIManager(apiUrl);
            fileService = new FileService(fileName, filePath);
            productService = new ProductService(apiManager, fileService);            
        }

        [When(@"product list received")]
        public void WhenProductListReceived()
        {
            results = productService.GetAll().Result;
        }

        [Then(@"filter should be applied")]
        public void ThenFilterShouldBeApplied()
        {
            filteredResults = productService.Filter(results, x => x.Rating.Rate >= 3 && x.Rating.Count >= 100).Result;
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(filteredResults);
            Assert.That(products.Where(x => x.Rating.Rate < 3 && x.Rating.Count < 100).Count() , Is.EqualTo(0));
        }

        [Then(@"price is formated")]
        public void ThenPriceIsFormated()
        {
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(filteredResults);
            string expected = string.Format("{0:C2}", 109.95);
            string actual = products.FirstOrDefault().Price.FormatAsCurrenty();

            Assert.That(expected == actual);
        }

        [Then(@"results written to file")]
        public void ThenResultsWrittenToFile()
        {
            productService.SaveResults(filteredResults);

            string fullFilePath = Path.Combine(filePath, fileName);
            Assert.That(File.Exists(fullFilePath), Is.True);
        }
    }
}
