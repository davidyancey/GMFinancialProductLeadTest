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

        /// <summary>
        /// Get all records from API
        /// </summary>
        /// <returns>JSON String</returns>
        public async Task<string> GetAll()
        {
            string results = await apiManager.GetAPIResults();
            
            return results;
        }

        /// <summary>
        /// Get filtered recrods from API
        /// </summary>
        /// <param name="where">
        ///     Predicate to be used as 
        ///     Get(x => x.Rating.Rate >= 3 && x.Rating.Count >= 100)
        ///     This places the control of the query of the data with who is using the data
        /// </param>
        /// <returns>JSON String</returns>
        public async Task<string> Get(Func<Product, bool> @where)
        {
            string content = await apiManager.GetAPIResults();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            var filteredProducts = products == null ? (IEnumerable<Product>)([]) : products.Where(@where);

            var results = JsonConvert.SerializeObject(filteredProducts);


            return results;

        }

        /// <summary>
        /// Applies a filter to a previously retrieved record set as json
        /// </summary>
        /// <param name="content">JSON</param>
        /// <param name="where">
        ///     Predicate to be used as 
        ///     Get(x => x.Rating.Rate >= 3 && x.Rating.Count >= 100)
        ///     This places the control of the query of the data with who is using the data
        /// </param>
        /// <returns>JSON string</returns>
        public async Task<string> Filter(string content, Func<Product, bool> @where)
        {
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            var filteredProducts = products == null ? (IEnumerable<Product>)([]) : products.Where(@where);

            var results = JsonConvert.SerializeObject(filteredProducts);


            return results;
        }

        /// <summary>
        /// Calls the Fileservice to save the results to the filesystem.
        /// </summary>
        /// <param name="results"></param>
        public void SaveResults(string results)
        {
            fileService.Write(results);
        }
    }
}
