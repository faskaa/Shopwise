using Microsoft.AspNetCore.Identity;

namespace BackEndProject.Entities
{
    public class CustomUser:IdentityUser
    {

        public ICollection<Wishlist> Wishlists { get; set; }

    }
}
