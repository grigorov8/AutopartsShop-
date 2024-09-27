using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;




namespace AutoPartsShop.Infrastructure.Database.Identity
{
    public class ApplicationDbContext : IdentityDbContext<AplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }





    }


}
