using Bootcamp.Queries.Stock;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.ViewModel;
using Dapper;

namespace Bootcamp.Queries.Stock
{
    public class StockQueries : IStockQueries
    {
        private readonly string _connectionString;

        public StockQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<StockViewModelwithProducto>> GetAll()
        {
            IEnumerable<StockViewModelwithProducto> result = new List<StockViewModelwithProducto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<StockViewModelwithProducto>("[dbo].[Usp_Sel_Stock]", commandType: CommandType.StoredProcedure);
            }

            return result;
        }

    }
}
