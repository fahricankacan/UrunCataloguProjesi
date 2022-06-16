using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.ProductOfferRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.ProductOfferRepositories
{
    public class ProductOfferReadRepository : IProductOfferReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public ProductOfferReadRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public IEnumerable<ProductOffer> GetAll()
        {
            return _connection.Query<ProductOffer>(ProductOfferSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public async Task<IEnumerable<ProductOffer>> GetAllAsync()
        {
            return await _connection.QueryAsync<ProductOffer>(ProductOfferSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public ProductOffer GetById(int id)
        {
            return _connection.QueryFirstOrDefault<ProductOffer>(ProductOfferSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task<ProductOffer> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<ProductOffer>(ProductOfferSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
