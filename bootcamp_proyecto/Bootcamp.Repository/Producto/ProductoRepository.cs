using Bootcamp.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Bootcamp.Repository.Producto
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Model.Producto producto)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", producto.Nombre);
            parameters.Add("@Precio", producto.Precio);
            parameters.Add("@Categoria", producto.Categoria);
            parameters.Add("@Descripcion", producto.Descripcion);
            parameters.Add("@Stock", producto.Stock);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_Producto]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
        /*public async Task<int> CreateProductWithStock(Model.ProductoWithStock producto)
        {
            int result;
            //var productoWithStock = new ProductoWithStock();

            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", producto.Nombre);
            parameters.Add("@Descripcion", producto.Descripcion);
            parameters.Add("@Precio", producto.Precio);
            parameters.Add("@Categoria", producto.Categoria);
            //parameters.Add("@ProductoId", producto.ProductoId);
            parameters.Add("@Total", producto.Total);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_ProductoStock]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }*/

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Del_Producto]", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Model.Producto producto)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@ProductoId", producto.ProductoId);
            parameters.Add("@Nombre", producto.Nombre);
            parameters.Add("@Descripcion", producto.Descripcion);
            parameters.Add("@Precio", producto.Precio);
            parameters.Add("@Categoria", producto.Categoria);
            parameters.Add("@Stock", producto.Stock);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Upd_Producto]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}