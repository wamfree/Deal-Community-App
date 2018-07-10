namespace DealCommunityShared.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string productCode { get; set; }
        public string releaseDate { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double starRating { get; set; }
        public string imageUrl { get; set; }
    }
}
