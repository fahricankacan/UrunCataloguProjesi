using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repostories.ProductRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.ProductRepositories
{
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public ProductReadRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public IEnumerable<Product> GetAll()
        {
            return _connection.Query<Product>(ProductSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _connection.QueryAsync<Product>(ProductSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public Product GetById(int id)
        {
            return _connection.QueryFirstOrDefault<Product>(ProductSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Product>(ProductSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
