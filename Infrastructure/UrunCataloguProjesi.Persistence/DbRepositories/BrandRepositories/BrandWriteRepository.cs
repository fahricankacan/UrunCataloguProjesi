using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repostories.BrandRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.BrandRepositories
{
    public class BrandWriteRepository : IBrandWriteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public BrandWriteRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public int Add(Brand entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = _connection.Execute(BrandSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public async Task<int> AddAsync(Brand entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = await _connection.ExecuteAsync(BrandSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public int Delete(int id)
        {
            return _connection.Execute(BrandSqlCommands.Delete, param: id, transaction: _dbTransaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync(BrandSqlCommands.Delete, param: id, transaction: _dbTransaction);

        }

        public int Update(Brand entity)
        {
            entity.UpdatedAt = DateTime.Now;
            return _connection.Execute(BrandSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }

        public async Task<int> UpdateAsync(Brand entity)
        {
            return await _connection.ExecuteAsync(BrandSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }
    }
}
