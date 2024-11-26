using Microsoft.AspNetCore.Identity;

namespace AutoPartsShop.Areas.Admin.Models
{
    public class UserRolesViewModel
    {

        public IdentityUser? User { get; set; } 
        public IList<string> Roles { get; set; } = new List<string>();

    }
}
