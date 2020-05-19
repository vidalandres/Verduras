using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Fruta> Frutas { get; set; }
    }
}