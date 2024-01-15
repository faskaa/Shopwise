namespace BackEndProject.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public override string ToString()
        {
            return Rate.ToString();
        }

        public ICollection<Product> Products { get; set; }
    }
}
