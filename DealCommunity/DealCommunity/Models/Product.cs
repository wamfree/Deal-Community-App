using System;
using Newtonsoft.Json;

namespace DealCommunity
{
    public class Product
    {
        [JsonProperty(PropertyName = "productId")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "productName")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "productCode")]
        public string Code { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
