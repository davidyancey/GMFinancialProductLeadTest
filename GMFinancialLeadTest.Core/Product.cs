namespace GMFinancialLeadTest.Core
{
    public class Product
    {
        private string price;

        public int Id { get; set; }
        public string Title { get; set; }


        public string Price { get => string.Format("{0:C2}", price); set => price = value; }
        public string Description { get; set; }
        public string Category { get; set; }   
        public string Image {  get; set; }
        public Rating Rating { get; set; }

    }

    public class Rating
    {
        public decimal Rate { get; set; }
        public int Count { get; set; }
    }
}
