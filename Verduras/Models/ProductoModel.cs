using Entity;

namespace Verduras.Models
{
    public class ProductoInputModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        public double Margen { get; set; }
        public double Precio { get; set; }
        public string Unidad { get; set; }
        public string Proveedor { get; set; }
    }

    public class ProductoViewModel : ProductoInputModel
    {
        public ProductoViewModel()
        {  
        }
        public ProductoViewModel(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre;
            Cantidad = producto.Cantidad;
            Unidad = producto.Unidad;
            Proveedor = producto.Proveedor;
            Costo = producto.Costo;
            Margen = producto.Margen;
            Precio = producto.Precio;
        }
    }

}