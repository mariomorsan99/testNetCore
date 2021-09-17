using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
        public class TiendaContext : DbContext {
           
            public TiendaContext(DbContextOptions<TiendaContext> options) : base (options) { }
    

            public DbSet<Producto> Producto { get; set; }
        }
    
}