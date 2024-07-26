using GMFinancialLeadTest.Core;
using Newtonsoft.Json;
namespace GMFinancialLeadTest.ProductDomain
{
    public class ProductService
    {
        private readonly IAPIManager apiManager;
        private readonly IFileService fileService;

        public ProductService(IAPIManager apiManager, IFileService fileService)
        {
            this.apiManager = apiManager;
            this.fileService = fileService;
        }

        public async Task<string> GetAll()
        {
            string results = await apiManager.GetAPIResults();
            
            return results;
        }

        public async Task<string> Get(Func<Product, bool> @where)
        {
            string content = await apiManager.GetAPIResults();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            var filteredProducts = products == null ? (IEnumerable<Product>)([]) : products.Where(@where);

            var results = JsonConvert.SerializeObject(filteredProducts);


            return results;

        }

        public async Task<string> Filter(string content, Func<Product, bool> @where)
        {
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            var filteredProducts = products == null ? (IEnumerable<Product>)([]) : products.Where(@where);

            var results = JsonConvert.SerializeObject(filteredProducts);


            return results;
        }

        public void SaveResults(string results)
        {
            fileService.Write(results);
        }
    }
}
