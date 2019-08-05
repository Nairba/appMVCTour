namespace appMVCTour.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TourContext : DbContext
    {
        public TourContext()
            : base("name=TourContext")
        {
        }

        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<reserva_tour> reserva_tour { get; set; }
        public virtual DbSet<tour> tour { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>()
                .HasMany(e => e.reserva_tour)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reserva_tour>()
                .Property(e => e.costoTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tour>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tour>()
                .Property(e => e.precioNinos)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tour>()
                .Property(e => e.precioAdultos)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tour>()
                .Property(e => e.restricciones)
                .IsUnicode(false);

            modelBuilder.Entity<tour>()
                .HasMany(e => e.reserva_tour)
                .WithRequired(e => e.tour)
                .WillCascadeOnDelete(false);
        }
    }
}
