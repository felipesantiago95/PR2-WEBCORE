using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PR2_WEBCORE.Models;

public partial class IngwebCoreContext : DbContext
{
    public IngwebCoreContext()
    {
    }

    public IngwebCoreContext(DbContextOptions<IngwebCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aforo> Aforos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Establecimiento> Establecimientos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aforo>(entity =>
        {
            entity.HasKey(e => e.IdAforo);

            entity.ToTable("aforo");

            entity.Property(e => e.IdAforo).HasColumnName("id_aforo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCagegoria);

            entity.ToTable("categoria");

            entity.Property(e => e.IdCagegoria).HasColumnName("id_cagegoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.IdClase);

            entity.ToTable("clase");

            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
        });

        modelBuilder.Entity<Establecimiento>(entity =>
        {
            entity.HasKey(e => e.IdEstablecimiento).HasName("PK__establec__AFEAEA203D3670D3");

            entity.ToTable("establecimiento");

            entity.Property(e => e.IdEstablecimiento).HasColumnName("id_establecimiento");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.RepresentanteLegal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("representante_legal");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSales);

            entity.ToTable("SALES");

            entity.Property(e => e.IdSales).HasColumnName("id_sales");
            entity.Property(e => e.IdAforo).HasColumnName("id_aforo");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.IdEstablecimiento).HasColumnName("id_establecimiento");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");

            entity.HasOne(d => d.IdAforoNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdAforo)
                .HasConstraintName("FK_SALES_aforo");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_SALES_categoria");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("FK_SALES_clase");

            entity.HasOne(d => d.IdEstablecimientoNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdEstablecimiento)
                .HasConstraintName("FK_SALES_establecimiento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_SALES_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04ADC585F44F");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUserRoles);

            entity.ToTable("usuario_rol");

            entity.Property(e => e.IdUserRoles).HasColumnName("id_user_roles");
            entity.Property(e => e.IdRoles).HasColumnName("id_roles");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdRolesNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_rol_roles");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_rol_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
