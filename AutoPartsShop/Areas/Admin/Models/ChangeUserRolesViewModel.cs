namespace AutoPartsShop.Areas.Admin.Models
{
    public class ChangeUserRolesViewModel
    {

        public string UserId { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public List<string> UserRoles { get; set; } = new List<string>();
        public List<string> AvailableRoles { get; set; } = new List<string>();

    }

}
