namespace BackEndProject.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<CustomUser> CustomUsers { get; set; }
    }
}
