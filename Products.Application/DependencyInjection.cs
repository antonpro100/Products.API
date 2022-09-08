using Microsoft.Extensions.DependencyInjection;
using Products.Application.Services;
using Products.Core.Interfaces;
using Products.Core.Mapping;

namespace Products.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new ProductsMappingProfile());
            });
            
            services.AddTransient<IProductsService, ProductsService>();

            return services;
        }
    }
}
