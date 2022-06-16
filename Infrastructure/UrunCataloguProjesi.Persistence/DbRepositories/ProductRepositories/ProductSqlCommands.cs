namespace UrunCataloguProjesi.Persistence.DbRepositories.ProductRepositories
{
    internal class ProductSqlCommands
    {
        internal const string Insert = "insert into [Product] (BrandId,UserId,Name,Description,State,CreatedAt) Values (@BrandId,@UserId,@Name,@Description,@State,@CreatedAt)";
        internal const string Update = "update [Product] set BrandId=@BrandId,UserId=@UserId,Name=@Name,Description=@Description,State=@State,UpdatedAt=@UpdatedAt";
        internal const string Delete = "delete from [Product] where Id=@Id";
        internal const string GetAll = "select * from [Product]";
        internal const string GetById = "select * from [Product] where Id=@Id";
    }
}
