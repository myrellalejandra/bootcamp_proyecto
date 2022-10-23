using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bootcamp.ViewModel;

namespace Bootcamp.Queries.Producto
{
    public interface IProductoQueries
    {
        Task<IEnumerable<ProductoViewModel>> GetAll();
    }
}
