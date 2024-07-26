using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMFinancialLeadTest.Core
{
    public class FileService : IFileService
    {
        private string _fileName;
        private string _filePath;

        public FileService(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public void Write(string content)
        {
            fileWriter(content);
        }

        private void fileWriter(string content)
        {
            string fullFilePath = Path.Combine(_filePath, _fileName);
            File.WriteAllText(fullFilePath, content);
        }
    }
}
