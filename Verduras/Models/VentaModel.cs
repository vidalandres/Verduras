using Entity;
using System;
using System.Collections.Generic;

namespace Verduras.Models
{
    public class VentaInputModel
    {
        public int Id { get; set; }
        public string Vendedor { get; set; }
        public List<Producto> Productos { get; set; }
        public double Total { get; set; }
        public double Utilidad { get; set; }
        public DateTime Fecha { get; set; }        

        public void GenUtilidad(){
            this.Utilidad = 0;
            this.Total = 0;
            this.Productos.ForEach(
                x => {
                    this.Utilidad += x.GenUtilidad();
                    x.GenPrecio();
                    this.Total += x.Precio;
                }
            );
        }
    }

    public class VentaViewModel : VentaInputModel
    {
        public VentaViewModel()
        {  
        }
        public VentaViewModel(VentaInputModel venta)
        {
            Id = venta.Id;
            Vendedor = venta.Vendedor;
            Productos = venta.Productos;
            Total = venta.Total;
            Utilidad = venta.Utilidad;
            Fecha = venta.Fecha;
        }
        public VentaViewModel(Venta venta)
        {
            Id = venta.Id;
            Vendedor = venta.Vendedor;
            //Productos = venta.Productos;
            Total = venta.Total;
            Utilidad = venta.Utilidad;
            Fecha = venta.Fecha;
        }
    }

}