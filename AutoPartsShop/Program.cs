using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Services;
using AutoPartsShop.Infrastructure.Database;
using AutoPartsShop.Infrastructure.Database.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AutoShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoContext")));



builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<AutoShopDbContext>()
    .AddDefaultTokenProviders();
    



builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews();
     

 builder.Services.AddScoped<IRepository, Repository>();
 builder.Services.AddScoped<ICarService, CarService>();
 builder.Services.AddScoped<IPartService, PartService>();



var app = builder.Build();





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
