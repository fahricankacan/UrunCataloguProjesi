using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.OfferRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.OfferRepositories
{
    public class OfferReadRepository : IOfferReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public OfferReadRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public IEnumerable<Offer> GetAll()
        {
            return _connection.Query<Offer>(OfferSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            return await _connection.QueryAsync<Offer>(OfferSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public Offer GetById(int id)
        {
            return _connection.QueryFirstOrDefault<Offer>(OfferSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task<Offer> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Offer>(OfferSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
