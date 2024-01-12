﻿namespace BackEndProject.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategory>  ProductCategories { get; set; }

    }
}
