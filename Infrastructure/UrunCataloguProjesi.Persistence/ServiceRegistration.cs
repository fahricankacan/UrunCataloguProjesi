using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.OfferRepositories;
using UrunCataloguProjesi.Application.Repositories.ProductOfferRepositories;
using UrunCataloguProjesi.Application.Repositories.UserRepositories;
using UrunCataloguProjesi.Application.Repostories;
using UrunCataloguProjesi.Application.Repostories.BrandRepositories;
using UrunCataloguProjesi.Application.Repostories.ProductRepositories;
using UrunCataloguProjesi.Persistence.DbRepositories;
using UrunCataloguProjesi.Persistence.DbRepositories.BrandRepositories;
using UrunCataloguProjesi.Persistence.DbRepositories.OfferRepositories;
using UrunCataloguProjesi.Persistence.DbRepositories.ProductOfferRepositories;
using UrunCataloguProjesi.Persistence.DbRepositories.ProductRepositories;
using UrunCataloguProjesi.Persistence.DbRepositories.UserRepositories;

namespace UrunCataloguProjesi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((s) => new SqlConnection(configuration.GetConnectionString("SqlServer")));
            #region DatabaseRepositories
            services.AddTransient<IBrandReadRepository, BrandReadRepository>();
            services.AddTransient<IBrandWriteRepository, BrandWriteRepository>();

            services.AddTransient<IUserReadRepository, UserReadRepository>();
            services.AddTransient<IUserWriteRepository, UserWriteRepository>();

            services.AddTransient<IProductReadRepository, ProductReadRepository>();
            services.AddTransient<IProductWriteRepository, ProductWriteRepository>();

            services.AddTransient<IOfferReadRepository, OfferReadRepository>();
            services.AddTransient<IOfferWriteRepository, OfferWriteRepository>();

            services.AddTransient<IProductOfferReadRepository, ProductOfferReadRepository>();
            services.AddTransient<IProductOfferWriteRepository, ProductOfferWriteRepository>();
            #endregion
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbTransaction>(s =>
            {
                SqlConnection connection = s.GetRequiredService<SqlConnection>();
                connection.Open();
                
                return connection.BeginTransaction();
            });
        }
    }
}
