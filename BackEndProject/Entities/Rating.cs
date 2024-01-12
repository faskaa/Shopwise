namespace BackEndProject.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
