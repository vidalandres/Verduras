using System.IO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public string Vendedor { get; set; }
        public double Total { get; set; }
        public double Utilidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}