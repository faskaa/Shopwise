namespace BackEndProject.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int? Offer { get; set; }


        public int RatingId { get; set; } 
        public Rating Rating { get; set; } 

        public ICollection<ProductCategory>  ProductCategories { get; set; }
    }
}
