using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPartsShop.Areas.Admin.Models
{

    public class AddUserViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> AvailableRoles { get; set; } = new List<string>();
    }


}
