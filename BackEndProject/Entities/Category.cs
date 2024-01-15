namespace BackEndProject.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsTop { get; set; }

        public ICollection<ProductCategory>  ProductCategories { get; set; }

    }
}
