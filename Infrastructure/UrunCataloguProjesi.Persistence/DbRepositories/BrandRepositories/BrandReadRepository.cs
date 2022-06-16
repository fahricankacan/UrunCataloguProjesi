using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UrunCataloguProjesi.Application.Repostories.BrandRepositories;
using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Persistence.DbRepositories.BrandRepositories
{
    public class BrandReadRepository : IBrandReadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly IDbTransaction _dbTransaction;

        public BrandReadRepository(IConfiguration configuration, SqlConnection connection, IDbTransaction dbTransaction)
        {
            _configuration = configuration;
            _connection = connection;
            _dbTransaction = dbTransaction;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _connection.Query<Brand>(BrandSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _connection.QueryAsync<Brand>(BrandSqlCommands.GetAll, transaction: _dbTransaction);
        }

        public Brand GetById(int id)
        {
            return _connection.QueryFirstOrDefault<Brand>(BrandSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Brand>(BrandSqlCommands.GetById, new { Id = id }, transaction: _dbTransaction);
        }
    }
}
