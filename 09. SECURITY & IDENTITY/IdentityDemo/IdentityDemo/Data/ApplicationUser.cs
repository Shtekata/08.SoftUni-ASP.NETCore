using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
