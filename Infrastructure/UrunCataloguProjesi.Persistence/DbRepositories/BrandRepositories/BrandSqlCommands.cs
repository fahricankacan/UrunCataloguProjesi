namespace UrunCataloguProjesi.Persistence.DbRepositories.BrandRepositories
{
    internal class BrandSqlCommands
    {
        internal const string Insert = "insert into [Brand] (Name,CreatedAt) Values (@Name,@CreatedAt)";
        internal const string Update = "update [Brand] set Name=@Name , UpdatedAt=@UpdatedAt";
        internal const string Delete = "delete from [Brand] where Id=@Id";
        internal const string GetAll = "select * from [Brand]";
        internal const string GetById = "select * from [Brand] where Id=@Id";
    }
}
