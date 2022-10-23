using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.ViewModel
{
    public class StockViewModelwithProducto
    {
        public int StockId { get; set; }
        public int ProductoId { get; set; }

        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Total { get; set; }
    }

    public class StockViewModel
    {
        public int StockId { get; set; }
        public int ProductoId { get; set; }
        public int Total { get; set; }
    }
}
