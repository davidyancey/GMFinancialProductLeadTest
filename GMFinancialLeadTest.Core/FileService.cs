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
            string fullFilePath = Path.Combine(_filePath, _fileName);
            if (!Directory.Exists(_filePath))
                Directory.CreateDirectory(_filePath);

            File.WriteAllText(fullFilePath, content);
        }       
    }
}
