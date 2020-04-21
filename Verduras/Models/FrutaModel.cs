using Entity;

namespace Verduras.Models
{
    public class FrutaInputModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Proveedor { get; set; }
    }

    public class FrutaViewModel : FrutaInputModel
    {
        public FrutaViewModel()
        {  
        }
        public FrutaViewModel(Fruta fruta)
        {
            Id = fruta.Id;
            Nombre = fruta.Nombre;
            Cantidad = fruta.Cantidad;
            Unidad = fruta.Unidad;
            Proveedor = fruta.Proveedor;
        }
    }

}