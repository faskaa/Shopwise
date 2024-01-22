namespace BackEndProject.Entities
{
    public class CustomUserWishlist
    {
        public int Id { get; set; }


        public CustomUser CustomUser { get; set; }

        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

    }
}
