using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.UserRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.UserRepositories
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public UserReadRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.Query<User>(UserSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _connection.QueryAsync<User>(UserSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public User GetById(int id)
        {
            return _connection.QueryFirstOrDefault<User>(UserSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<User>(UserSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
