using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pryDemoCrudWebApi.Models
{
    public partial class dbtestContext : DbContext
    {
        public dbtestContext()
        {
        }

        public dbtestContext(DbContextOptions<dbtestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbcliente> Tbcliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=dbcruddemo.cuootw9zi6fj.us-east-2.rds.amazonaws.com;Database=dbtest;User Id=admin;Password=administrador;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Tbcliente>(entity =>
            {
                entity.ToTable("tbcliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(100);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(20);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(300);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(100);
            });
        }
    }
}
