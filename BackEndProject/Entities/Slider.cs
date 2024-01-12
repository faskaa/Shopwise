namespace BackEndProject.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; }= null!;
        public string URL { get; set; } = null!;
        public string BgImage { get; set; } = null!;
    }
}
