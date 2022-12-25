using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFDI.API.Entidades;

public partial class ProyectoFdiContext : DbContext
{
    public ProyectoFdiContext()
    {
    }

    public ProyectoFdiContext(DbContextOptions<ProyectoFdiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deportistum> Deportista { get; set; }

    public virtual DbSet<Modalidad> Modalidads { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\Servidor;Initial Catalog=ProyectoFDI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deportistum>(entity =>
        {
            entity.HasKey(e => e.IdDep).HasName("PK__Deportis__6EC86342ADFF9F4B");

            entity.Property(e => e.IdDep).HasColumnName("id_Dep");
            entity.Property(e => e.ApellidosDep)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos_Dep");
            entity.Property(e => e.CategoriaDep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("categoria_Dep");
            entity.Property(e => e.CedulaDep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedula_Dep");
            entity.Property(e => e.ClubDep)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("club_Dep");
            entity.Property(e => e.GeneroDep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_Dep");
            entity.Property(e => e.IdMod).HasColumnName("id_Mod");
            entity.Property(e => e.NombresDep)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres_Dep");
            entity.Property(e => e.ProvinciaDep)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("provincia_Dep");

            entity.HasOne(d => d.IdModNavigation).WithMany(p => p.Deportista)
                .HasForeignKey(d => d.IdMod)
                .HasConstraintName("FK__Deportist__id_Mo__412EB0B6");
        });

        modelBuilder.Entity<Modalidad>(entity =>
        {
            entity.HasKey(e => e.IdMod).HasName("PK__Modalida__748AD5DC3A4EAF07");

            entity.ToTable("Modalidad");

            entity.Property(e => e.IdMod).HasColumnName("id_Mod");
            entity.Property(e => e.DescripcionMod)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion_Mod");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Usuario");

            entity.Property(e => e.ClaveUsuario)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("clave_usuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.RolesUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("roles_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
