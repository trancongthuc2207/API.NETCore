using Microsoft.AspNetCore.Identity;

namespace APITestApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;

    }
}
