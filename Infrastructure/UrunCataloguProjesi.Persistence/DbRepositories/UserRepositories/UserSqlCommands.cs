namespace UrunCataloguProjesi.Persistence.DbRepositories.UserRepositories
{
    internal class UserSqlCommands
    {
        internal const string Insert = "insert into [User] (Name,Surname,Email,PasswordSalt,PasswordHash,IsActive,CreatedAt) Values (@Name,@Surname,@Email,@PasswordSalt,@PasswordHash,@IsActive,@CreatedAt)";
        internal const string Update = "update [User] set Name=@Name,Surname=@Surname,Email=@Email,PasswordSalt=@PasswordSalt,PasswordHash=@PasswordHash,IsActive=@IsActive,UpdatedAt=@UpdatedAt";
        internal const string Delete = "delete from [User] where Id=@Id";
        internal const string GetAll = "select * from [User]";
        internal const string GetById = "select * from [User] where Id=@Id";
    }
}
