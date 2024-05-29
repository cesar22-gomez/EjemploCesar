using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatosBD.Models;

public class Proyecto1BdContext : DbContext
{
    public Proyecto1BdContext()
    {
    }

    public Proyecto1BdContext(DbContextOptions<Proyecto1BdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administrador { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<DetallesOrden> DetallesOrden { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<EntradasProductos> EntradasProductos { get; set; }

    public virtual DbSet<Logueo> Logueo { get; set; }

    public virtual DbSet<Mensajes> Mensajes { get; set; }

    public virtual DbSet<OrdenesCompra> OrdenesCompra { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GãMEZ\\CESARSERVER;Database=Proyecto1BD;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Administ__958BE6F0FE614751");

            entity.HasIndex(e => e.Usuario, "UQ__Administ__E3237CF7D445A038").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C59717D81A");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7508B6A06");

            entity.HasIndex(e => e.Usuario, "UQ__Clientes__E3237CF72D8D1634").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Barrio)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Canton)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DireccionExacta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Distrito)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.MarcaTarjeta)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTarjeta)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TarjetaTipo)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Telefono1)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Telefono2)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetallesOrden>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__Detalles__6E19D6FAF7D2BDEE");

            entity.ToTable(tb => tb.HasTrigger("ActualizarStockDespuesDeVenta"));

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Orden).WithMany(p => p.DetallesOrden)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesO__Orden__18B6AB08");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesOrden)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesO__Produ__19AACF41");
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F0906545A3");

            entity.HasIndex(e => e.Usuario, "UQ__Empleado__E3237CF7F25AC638").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EntradasProductos>(entity =>
        {
            entity.HasKey(e => e.EntradaId).HasName("PK__Entradas__A084659411C3AF1D");

            entity.Property(e => e.EntradaId).HasColumnName("EntradaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.EntradasProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EntradasP__Produ__13F1F5EB");
        });

        modelBuilder.Entity<Logueo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logueo__3214EC27FDF2C69D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mensajes>(entity =>
        {
            entity.HasKey(e => e.MensajeId).HasName("PK__Mensajes__FEA0557FDE79B282");

            entity.Property(e => e.MensajeId).HasColumnName("MensajeID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Mensajes__Client__0B5CAFEA");
        });

        modelBuilder.Entity<OrdenesCompra>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__OrdenesC__C088A4E4B4ECA22E");

            entity.Property(e => e.OrdenId)
                .ValueGeneratedNever()
                .HasColumnName("OrdenID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenesCompra)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_OrdenesCompra_Clientes");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE835F1384E1");

            entity.ToTable(tb => tb.HasTrigger("ComprarProductosPorBajoStock"));

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Presentacion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Tamano)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Categ__11158940");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
