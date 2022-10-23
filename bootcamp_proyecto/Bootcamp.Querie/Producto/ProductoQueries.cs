using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.Producto
{
    public class ProductoQueries : IProductoQueries
    {
        private readonly string _connectionString;
        public ProductoQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<ProductoViewModel>> GetAll()
        {
            IEnumerable<ProductoViewModel> result = new List<ProductoViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ProductoViewModel>("[dbo].[Usp_Sel_Producto]", commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
