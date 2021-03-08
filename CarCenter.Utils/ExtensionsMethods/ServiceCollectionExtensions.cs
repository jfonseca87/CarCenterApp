using CarCenter.Repository.EFImplementations;
using CarCenter.Repository.Interfaces;
using CarCenter.Services.EFImplementations;
using CarCenter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarCenter.Utils.ExtensionsMethods
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection DIRepositoryContainer(this IServiceCollection services) 
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICarroRepository, CarroRepository>();

            return services;
        }

        public static IServiceCollection DIBusinessContainer(this IServiceCollection services)
        {
            services.AddTransient<IClienteBusiness, ClienteBusiness>();
            services.AddTransient<ICarroBusiness, CarroBusiness>();

            return services;
        }
    }
}
