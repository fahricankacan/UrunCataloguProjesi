using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.UserRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.UserRepositories
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public UserWriteRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public int Add(User entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = _connection.Execute(UserSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public async Task<int> AddAsync(User entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = await _connection.ExecuteAsync(UserSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public int Delete(int id)
        {
            return _connection.Execute(UserSqlCommands.Delete, param: id, transaction: _dbTransaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync(UserSqlCommands.Delete, param: id, transaction: _dbTransaction);

        }

        public int Update(User entity)
        {
            entity.UpdatedAt = DateTime.Now;
            return _connection.Execute(UserSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }

        public async Task<int> UpdateAsync(User entity)
        {
            return await _connection.ExecuteAsync(UserSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }
    }
}
