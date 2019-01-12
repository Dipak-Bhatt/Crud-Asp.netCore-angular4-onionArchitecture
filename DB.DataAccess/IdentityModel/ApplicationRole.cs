using Microsoft.AspNetCore.Identity;

namespace DB.DataAccess.IdentityModel
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }

    }
}
