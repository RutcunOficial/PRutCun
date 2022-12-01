using PRutCun.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PRutCun.Context
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalleTransitada>()
            .HasKey(c => new { c.FkCalle, c.FkTransporte });
            modelBuilder.Entity<PuntoTransitado>()
            .HasKey(c => new { c.FkPunto, c.FkTransporte });
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Calle> Calle { get; set; }
        public DbSet<Transporte> Trasporte { get; set; }
        public DbSet<Mapas>Mapas { get; set; }
        public DbSet<CalleTransitada> CalleTransitada { get; set; }
        public DbSet<PuntoInteres> PuntoInteres { get; set; }
        public DbSet<PuntoTransitado> PuntoTransitado { get; set; }
        public DbSet<TipoTransporte> TipoTrasporte { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
