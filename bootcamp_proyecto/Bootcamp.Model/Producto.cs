namespace Bootcamp.Model
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }

    }

    public class ProductoWithStock
    {
        //public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Categoria { get; set; }
        public int Total { get; set; }
    }
}