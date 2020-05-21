using System.IO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Vendido
    {
        [Key]
        public int Id { get; set; }
        public Venta Vent { get; set; }

        [ForeignKey("Vent")]
        public int Venta { get; set; }
        public Producto Product { get; set; }

        [ForeignKey("Product")]
        public int Producto { get; set; }

        public Vendido()
        {
            
        }        
        public Vendido(Producto producto, int venta)
        {
            this.Producto = producto.Id;
            this.Venta = venta;
        }
    }
}