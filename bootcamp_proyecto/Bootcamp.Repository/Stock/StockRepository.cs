using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Bootcamp.Repository.Stock
{
    public class StockRepository : IStockRepository
    {
        private readonly string _connectionString;

        public StockRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Model.Stock stock)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@ProductoId", stock.ProductoId);
            parameters.Add("@Total", stock.Total);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_Stock]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@StockId", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Del_Stock]", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Model.Stock stock)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@stockId", stock.StockId);
            parameters.Add("@ProductoId", stock.ProductoId);
            parameters.Add("@Total", stock.Total);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Upd_Stock]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}