using GMFinancialLeadTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMFinancialLeadTest.UnitTests
{
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
