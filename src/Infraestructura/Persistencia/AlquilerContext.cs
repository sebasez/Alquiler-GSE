using Infraestructura.Persistencia.Modelos;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infraestructura.Persistencia
{
    public partial class AlquilerContext : DbContext
    {
        public AlquilerContext(DbContextOptions<AlquilerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquiler { get; set; }
        public virtual DbSet<Camara> Camara{ get; set; }
        public virtual DbSet<Cliente> Cliente{ get; set; }
        public virtual DbSet<Estado> Estado{ get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
