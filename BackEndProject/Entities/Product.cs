namespace BackEndProject.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Capacity { get; set; }
        public string WaterResistance { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public int? Offer { get; set; }
        public bool IsTrend { get; set; }


        public int RatingId { get; set; } 
        public Rating Rating { get; set; }

        public ICollection<ProductImage> ProductImage { get; set; } = null!;

        public ICollection<ProductInformation> ProductInformation { get; set; }
        public ICollection<ProductCategory>  ProductCategories { get; set; }
    }
}
