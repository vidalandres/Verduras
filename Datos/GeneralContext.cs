using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions options) : base(options)
        {   
            
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        
        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vendido> Vendidos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}