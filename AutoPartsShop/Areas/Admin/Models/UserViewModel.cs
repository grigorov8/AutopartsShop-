namespace AutoPartsShop.Areas.Admin.Models
{

    public class UserViewModel
    {

        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IList<string> Roles { get; set; } = new List<string>();
    }


}
