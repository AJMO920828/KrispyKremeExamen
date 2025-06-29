using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infraestructura.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.VentasCreadas)
                .WithOne(v => v.UsuarioAlta)
                .HasForeignKey(v => v.UsuarioAltaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.VentasModificadas)
                .WithOne(v => v.UsuarioModificacion)
                .HasForeignKey(v => v.UsuarioModificacionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
