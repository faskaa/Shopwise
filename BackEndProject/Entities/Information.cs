namespace BackEndProject.Entities
{
    public class Information
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ICollection<ProductInformation> ProductInformation { get; set; }


    }
}
