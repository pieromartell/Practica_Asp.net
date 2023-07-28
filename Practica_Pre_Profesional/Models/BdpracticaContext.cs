using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practica_Pre_Profesional.Models;

public partial class BdpracticaContext : DbContext
{
    public BdpracticaContext()
    {
    }

    public BdpracticaContext(DbContextOptions<BdpracticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAsignatura> TbAsignaturas { get; set; }

    public virtual DbSet<TbLibro> TbLibros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=FAMILIA-MARTELL; DataBase=BDPractica; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAsignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsig).HasName("PK__TB_Asign__B015D892080B41D7");

            entity.ToTable("TB_Asignatura");

            entity.Property(e => e.IdAsig).HasColumnName("id_asig");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TbLibro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__TB_LIBRO__D27DCC8C0016BDA8");

            entity.ToTable("TB_LIBRO");

            entity.Property(e => e.IdLibro).HasColumnName("Id_libro");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdAsing).HasColumnName("id_asing");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdAsingNavigation).WithMany(p => p.TbLibros)
                .HasForeignKey(d => d.IdAsing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asignatura_Key");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
