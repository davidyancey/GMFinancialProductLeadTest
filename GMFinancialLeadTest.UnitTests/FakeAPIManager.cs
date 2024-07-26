using GMFinancialLeadTest.Core;

namespace GMFinancialLeadTest.UnitTests
{
    /// <summary>
    /// Used for test purposes, this will return the json without the need to cross system boundaries
    /// </summary>
    public class FakeAPIManager : IAPIManager
    {
        public async Task<string> GetAPIResults()
        {
            string fileName = "FakeAPIResults.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            string[] lines = await File.ReadAllLinesAsync(filePath);
            return string.Join(Environment.NewLine, lines);
        }
    }
}
