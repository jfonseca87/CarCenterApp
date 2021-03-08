using System;
using CarCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarCenter.Repository.EFImplementations
{
    public partial class CarCenterContext : DbContext
    {
        public CarCenterContext()
        {
        }

        public CarCenterContext(DbContextOptions<CarCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carros> Carros { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleFacturas> DetalleFacturas { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Mecanicos> Mecanicos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Sedes> Sedes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Carros>(entity =>
            {
                entity.HasKey(e => e.CarroId)
                    .HasName("PK__Carros__10AB29E5E8617966");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Carros)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Carros__ClienteI__2E1BDC42");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__Clientes__71ABD0879C329BFE");

                entity.Property(e => e.TipoCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK__Clientes__Person__2B3F6F97");
            });

            modelBuilder.Entity<DetalleFacturas>(entity =>
            {
                entity.HasKey(e => e.DetalleFacturaId)
                    .HasName("PK__DetalleF__2318ABF5D6525F2E");

                entity.Property(e => e.TotalDetalle).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK__DetalleFa__Factu__36B12243");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__DetalleFa__Produ__35BCFE0A");
            });

            modelBuilder.Entity<Facturas>(entity =>
            {
                entity.HasKey(e => e.FacturaId)
                    .HasName("PK__Facturas__5C0248650F510C05");

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.Property(e => e.Subtotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ValorIva).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Facturas__Client__32E0915F");

                entity.HasOne(d => d.Sede)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.SedeId)
                    .HasConstraintName("FK__Facturas__SedeId__37A5467C");
            });

            modelBuilder.Entity<Mecanicos>(entity =>
            {
                entity.HasKey(e => e.MecanicoId)
                    .HasName("PK__Mecanico__D68834E123EE7F18");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Mecanicos)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK__Mecanicos__Perso__286302EC");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.PersonaId)
                    .HasName("PK__Personas__7C34D30360FA0C2F");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK__Producto__A430AEA3E11D1661");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorUnitario).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Sedes>(entity =>
            {
                entity.HasKey(e => e.SedeId)
                    .HasName("PK__Sedes__FD76DFDB71A48E30");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}