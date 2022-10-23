using Bootcamp.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public interface IProductoRepository
    {
        Task<int> Create(Producto producto);

        //Task<int> CreateProductWithStock(ProductoWithStock producto);

        Task<int> Update(Producto producto);

        Task<int> Delete(int id);
       
    }


