using System.IO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        public double Margen { get; set; }
        public double Precio { get; set; }
        public string Unidad { get; set; }
        public string Proveedor { get; set; }

        public void GenPrecio() {
            this.Precio = this.Costo + (this.Costo * this.Margen / 100);
        }

        public double GenUtilidad() {
            return this.Precio - this.Costo;
        }
    }
}