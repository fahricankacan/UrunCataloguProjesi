namespace UrunCataloguProjesi.Persistence.DbRepositories.OfferRepositories
{
    internal class OfferSqlCommands
    {
        internal const string Insert = "insert into [Offer] (Price,UserId,IsActive,CreatedAt) Values (@Price,@UserId,@IsActive,@CreatedAt)";
        internal const string Update = "update [Offer] set Price=@Price,UserId=@UserId,IsActive=@IsActive,UpdatedAt=@UpdatedAt";
        internal const string Delete = "delete from [Offer] where Id=@Id";
        internal const string GetAll = "select * from [Offer]";
        internal const string GetById = "select * from [Offer] where Id=@Id";
    }
}
