using Microsoft.AspNetCore.Identity;

namespace eBusiness.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
