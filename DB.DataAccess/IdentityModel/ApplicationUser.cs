using Microsoft.AspNetCore.Identity;

namespace DB.DataAccess.IdentityModel
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public string Image { get; set; }

    }
}
