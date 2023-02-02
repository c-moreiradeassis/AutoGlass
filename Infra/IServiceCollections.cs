using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Data.Context;
using Data.Repositories;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class IServiceCollections
    {
        private const string CONNECTION_STRING = "DefaultConnection";

        public static IServiceCollection AddContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapperApi(typeof(MapperProfile))
                    .AddServices()
                    .AddDbContext(configuration);

            return services;
        }

        public static IServiceCollection AddAutoMapperApi(this IServiceCollection services, Type assemblyContainingMappers)
        {
            services.AddAutoMapper(expression =>
            {
                expression.AllowNullCollections = true;
            }, assemblyContainingMappers);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ProductManagerService, ProductManagerServiceImp>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = GetDbConnectionString(configuration);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddScoped<BaseRepository, BaseRepositoryImp>();
            services.AddScoped<ProductsRepository, ProductsRepositoryImp>();

            return services;
        }

        private static string GetDbConnectionString(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(CONNECTION_STRING) ?? string.Empty;

            return connectionString;
        }
    }
}
