using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.ProductOfferRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.ProductOfferRepositories
{
    public class ProductOfferWriteRepository : IProductOfferWriteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public ProductOfferWriteRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public int Add(ProductOffer entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = _connection.Execute(ProductOfferSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public async Task<int> AddAsync(ProductOffer entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = await _connection.ExecuteAsync(ProductOfferSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public int Delete(int id)
        {
            return _connection.Execute(ProductOfferSqlCommands.Delete, param: id, transaction: _dbTransaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync(ProductOfferSqlCommands.Delete, param: id, transaction: _dbTransaction);

        }

        public int Update(ProductOffer entity)
        {
            entity.UpdatedAt = DateTime.Now;
            return _connection.Execute(ProductOfferSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }

        public async Task<int> UpdateAsync(ProductOffer entity)
        {
            return await _connection.ExecuteAsync(ProductOfferSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }
    }
}
