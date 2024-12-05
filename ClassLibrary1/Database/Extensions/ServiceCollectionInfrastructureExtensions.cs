using AutoPartsShop.Infrastructure.Database.Common;
using Microsoft.Extensions.DependencyInjection;


namespace AutoPartsShop.Infrastructure.Database.Extensions
{
    public static class ServiceCollectionInfrastructureExtensions
    {

        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {

            services.AddScoped<IRepository, Repository>();
           

            return services;
        }



    }


}
