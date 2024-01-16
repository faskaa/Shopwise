namespace BackEndProject.Entities
{
    public class ProductInformation
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InformationId { get; set; }
        public Information Information { get; set; }
    }
}
