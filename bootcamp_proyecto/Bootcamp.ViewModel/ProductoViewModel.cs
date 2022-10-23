using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.ViewModel
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }

    }
}
