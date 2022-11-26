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
            .HasKey(c => new { c.FkCalle, c.FkTrasporte });
            modelBuilder.Entity<PuntoTransitado>()
            .HasKey(c => new { c.FkPunto, c.FkTrasporte });
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Calle> Calle { get; set; }
        public DbSet<Trasporte> Trasporte { get; set; }
        public DbSet<CalleTransitada> CalleTransitada { get; set; }
        public DbSet<PuntoInteres> PuntoInteres { get; set; }
        public DbSet<PuntoTransitado> PuntoTransitado { get; set; }
        public DbSet<TipoTrasporte> TipoTrasporte { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
