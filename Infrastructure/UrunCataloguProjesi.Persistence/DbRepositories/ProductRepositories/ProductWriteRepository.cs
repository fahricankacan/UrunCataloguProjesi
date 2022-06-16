using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repostories.ProductRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.ProductRepositories
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public ProductWriteRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public int Add(Product entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = _connection.Execute(ProductSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public async Task<int> AddAsync(Product entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = await _connection.ExecuteAsync(ProductSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public int Delete(int id)
        {
            return _connection.Execute(ProductSqlCommands.Delete, param: id, transaction: _dbTransaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync(ProductSqlCommands.Delete, param: id, transaction: _dbTransaction);

        }

        public int Update(Product entity)
        {
            entity.UpdatedAt = DateTime.Now;
            return _connection.Execute(ProductSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            return await _connection.ExecuteAsync(ProductSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }
    }
}
