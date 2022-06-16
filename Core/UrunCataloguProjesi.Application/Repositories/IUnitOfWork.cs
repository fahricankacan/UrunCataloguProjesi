using System.Data;
using UrunCataloguProjesi.Application.Repositories.OfferRepositories;
using UrunCataloguProjesi.Application.Repositories.ProductOfferRepositories;
using UrunCataloguProjesi.Application.Repositories.UserRepositories;
using UrunCataloguProjesi.Application.Repostories.BrandRepositories;
using UrunCataloguProjesi.Application.Repostories.ProductRepositories;

namespace UrunCataloguProjesi.Application.Repostories
{
    public interface IUnitOfWork
    {
        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }

        IBrandReadRepository BrandReadRepository { get; }
        IBrandWriteRepository BrandWriteRepository { get; }

        IOfferReadRepository OfferReadRepository { get; }
        IOfferWriteRepository OfferWriteRepository { get; }

        IProductOfferReadRepository ProductOfferReadRepository { get; }
        IProductOfferWriteRepository ProductOfferWriteRepository { get; }

        IUserReadRepository UserReadRepository { get; }
        IUserWriteRepository UserWriteRepository { get; }

        IDbTransaction DbTransaction { get; set; }

        void Commit();
    }
}
