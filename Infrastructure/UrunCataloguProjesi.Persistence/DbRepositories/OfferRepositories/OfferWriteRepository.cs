using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repositories.OfferRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.OfferRepositories
{
    public class OfferWriteRepository : IOfferWriteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public OfferWriteRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public int Add(Offer entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = _connection.Execute(OfferSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public async Task<int> AddAsync(Offer entity)
        {
            entity.CreatedAt = DateTime.Now;
            var result = await _connection.ExecuteAsync(OfferSqlCommands.Insert, param: entity, transaction: _dbTransaction);
            return result;
        }

        public int Delete(int id)
        {
            return _connection.Execute(OfferSqlCommands.Delete, param: id, transaction: _dbTransaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync(OfferSqlCommands.Delete, param: id, transaction: _dbTransaction);

        }

        public int Update(Offer entity)
        {
            entity.UpdatedAt = DateTime.Now;
            return _connection.Execute(OfferSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }

        public async Task<int> UpdateAsync(Offer entity)
        {
            return await _connection.ExecuteAsync(OfferSqlCommands.Update, param: entity, transaction: _dbTransaction);
        }
    }
}
