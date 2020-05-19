using System.IO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Fruta
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Proveedor { get; set; }
    }
}