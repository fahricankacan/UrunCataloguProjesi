namespace UrunCataloguProjesi.Persistence.DbRepositories.ProductOfferRepositories
{
    internal class ProductOfferSqlCommands
    {
        internal const string Insert = "insert into [ProductOffer] (ProductId,OfferId,DealDone,CreatedAt) Values (@ProductId,@OfferId,@DealDone,@CreatedAt)";
        internal const string Update = "update [ProductOffer] set ProductId=@ProductId,OfferId=@OfferId,DealDone=@DealDone,UpdatedAt=@UpdatedAt";
        internal const string Delete = "delete from [ProductOffer] where Id=@Id";
        internal const string GetAll = "select * from [ProductOffer]";
        internal const string GetById = "select * from [ProductOffer] where Id=@Id";
    }
}
