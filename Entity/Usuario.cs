using System.IO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }
}