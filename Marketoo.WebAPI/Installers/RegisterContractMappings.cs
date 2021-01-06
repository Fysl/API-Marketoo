using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Marketoo.WebAPI.Contracts;
using Marketoo.Services.Interfaces;
using Marketoo.Repository.Abstractions.Interfaces;
using Marketoo.Services.Services.ProductServices;
using Marketoo.Repository.Repositories.ProductRepositories;
using Marketoo.Repository.Repositories.SellerRepositories;
using Marketoo.Services.Services.SellerServices;

namespace Marketoo.WebAPI.Installers
{
    public class RegisterContractMappings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Register Interface Mappings - Repositories

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            #endregion

            #region Register Interface Mappings - Services

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISellerService, SellerService>();
            #endregion
        }
    }
}
