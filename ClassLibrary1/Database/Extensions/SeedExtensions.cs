using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace AutoPartsShop.Infrastructure.Database.Extensions
{
    public static class SeedExtensions
    {

        public static async Task SeedRolesAndAdminAsync(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            
            string[] roles = { "Admin", "Manager", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {

                    await roleManager.CreateAsync(new IdentityRole(role));

                }

            }

           
            var adminEmail = "grigorov@gmail.com";
            var adminPassword = "admin123";


            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {

                var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var result = await userManager.CreateAsync(admin, adminPassword);

                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(admin, "Admin");

                }

            }

        }


    }


}
