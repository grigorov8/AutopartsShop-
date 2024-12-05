using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AutoPartsShop.Core.Extensions
{
    public static class ServiceCollectionCoreExtensions
    {

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IProductService, ProductService>();

            return services;

        }


    }

}
