using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.OfferRepositories;
using UrunCataloguProjesi.Application.Repositories.ProductOfferRepositories;
using UrunCataloguProjesi.Application.Repositories.UserRepositories;
using UrunCataloguProjesi.Application.Repostories;
using UrunCataloguProjesi.Application.Repostories.BrandRepositories;
using UrunCataloguProjesi.Application.Repostories.ProductRepositories;

namespace UrunCataloguProjesi.Persistence.DbRepositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IProductReadRepository ProductReadRepository { get; }
        public IProductWriteRepository ProductWriteRepository { get; }

        public IBrandReadRepository BrandReadRepository { get; }
        public IBrandWriteRepository BrandWriteRepository { get; }

        public IOfferReadRepository OfferReadRepository { get; }
        public IOfferWriteRepository OfferWriteRepository { get; }

        public IProductOfferReadRepository ProductOfferReadRepository { get; }
        public IProductOfferWriteRepository ProductOfferWriteRepository { get; }

        public IUserReadRepository UserReadRepository { get; }
        public IUserWriteRepository UserWriteRepository { get; }

        public IDbTransaction DbTransaction { get; set; }
        public IConfiguration Configuration;

        public UnitOfWork(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IBrandReadRepository brandReadRepository, IBrandWriteRepository brandWriteRepository, IOfferReadRepository offerReadRepository, IOfferWriteRepository offerWriteRepository, IProductOfferReadRepository productOfferReadRepository, IProductOfferWriteRepository productOfferWriteRepository, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IDbTransaction dbTransaction, IConfiguration configuration)
        {
            ProductReadRepository = productReadRepository ?? throw new ArgumentNullException(nameof(productReadRepository));
            ProductWriteRepository = productWriteRepository ?? throw new ArgumentNullException(nameof(productWriteRepository));
            BrandReadRepository = brandReadRepository ?? throw new ArgumentNullException(nameof(brandReadRepository));
            BrandWriteRepository = brandWriteRepository ?? throw new ArgumentNullException(nameof(brandWriteRepository));
            OfferReadRepository = offerReadRepository ?? throw new ArgumentNullException(nameof(offerReadRepository));
            OfferWriteRepository = offerWriteRepository ?? throw new ArgumentNullException(nameof(offerWriteRepository));
            ProductOfferReadRepository = productOfferReadRepository ?? throw new ArgumentNullException(nameof(productOfferReadRepository));
            ProductOfferWriteRepository = productOfferWriteRepository ?? throw new ArgumentNullException(nameof(productOfferWriteRepository));
            UserReadRepository = userReadRepository ?? throw new ArgumentNullException(nameof(userReadRepository));
            UserWriteRepository = userWriteRepository ?? throw new ArgumentNullException(nameof(userWriteRepository));
            DbTransaction = dbTransaction ?? throw new ArgumentNullException(nameof(dbTransaction));
            Configuration = configuration;
        }

        public void Commit()
        {
            try
            {
                
                DbTransaction.Commit();
                //using (SqlConnection conn2 = new SqlConnection(Configuration.GetConnectionString("SqlServer"))) 
                //{
                //    conn2.BeginTransaction();
                //}
                //DbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                DbTransaction.Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            DbTransaction.Connection?.Close();
            DbTransaction.Connection?.Dispose();
            DbTransaction.Dispose();
        }
    }
}
