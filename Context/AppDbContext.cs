using apisGestores.Models;
using Microsoft.EntityFrameworkCore;

namespace apisGestores.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Gestores_Bd> gestores_Bd { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gestores_Bd>(entity =>
            {
                entity.ToTable("gestores_Bd");
                entity.Property(e => e.Id).HasColumnName("Id");

      
                entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.Lanzamiento)
.HasColumnName("Lanzamiento")
.IsRequired();

                entity.Property(e => e.Desarrollador)
                 .HasColumnName("Desarrollador")
                 .HasMaxLength(50)
                 .IsRequired();

            });

        }
    }
}
