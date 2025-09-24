using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

public partial class ElzyraContext : DbContext
{
    public ElzyraContext()
    {
    }

    public ElzyraContext(DbContextOptions<ElzyraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacene> Almacenes { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<ComprasOdc> ComprasOdcs { get; set; }

    public virtual DbSet<ComprasOdcDetalle> ComprasOdcDetalles { get; set; }

    public virtual DbSet<CotizacionCliente> CotizacionClientes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EmpresaParam> EmpresaParams { get; set; }

    public virtual DbSet<Gcompra> Gcompras { get; set; }

    public virtual DbSet<GcomprasDetalle> GcomprasDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S5Q2S88;Database=ELZYRA;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Almacene>(entity =>
        {
            entity.Property(e => e.CoAlma).IsFixedLength();

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Almacenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacenes_Empresas");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.Property(e => e.IdTipo).IsFixedLength();
            entity.Property(e => e.NombreCompleto).IsFixedLength();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.AspNetUsers).HasConstraintName("FK_AspNetRolesUsers");
        });

        modelBuilder.Entity<ComprasOdcDetalle>(entity =>
        {
            entity.HasOne(d => d.IdOdcNavigation).WithMany(p => p.ComprasOdcDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_compras_ODC_detalle_compras_ODC");
        });

        modelBuilder.Entity<CotizacionCliente>(entity =>
        {
            entity.HasKey(e => e.IdCot).HasName("PK_Cotizacion_Client_cotizaciones");

            entity.ToTable("Cotizacion_Cliente", tb => tb.HasTrigger("cotizacion_cliente_actualizarVentasMuestrasCliente"));

            entity.Property(e => e.Aprobado).HasDefaultValue(false);
            entity.Property(e => e.CoCli).IsFixedLength();
            entity.Property(e => e.CoVen).IsFixedLength();
            entity.Property(e => e.CondiPago).IsFixedLength();
            entity.Property(e => e.DescuentoUsd).HasDefaultValue(0m);
            entity.Property(e => e.Direccion).IsFixedLength();
            entity.Property(e => e.Empresa).IsFixedLength();
            entity.Property(e => e.FeUsIn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FeUsMo).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Moneda).IsFixedLength();
            entity.Property(e => e.NegociacionEspecial).HasDefaultValue(false);
            entity.Property(e => e.Nombre).IsFixedLength();
            entity.Property(e => e.Observacion).IsFixedLength();
            entity.Property(e => e.OrdenCp).HasDefaultValue("");
            entity.Property(e => e.Rif).IsFixedLength();
            entity.Property(e => e.SubTotalUsd).HasDefaultValue(0m);
            entity.Property(e => e.Tasa).HasDefaultValue(1m);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.Property(e => e.AjEntrada).IsFixedLength();
            entity.Property(e => e.AjSalida).IsFixedLength();
            entity.Property(e => e.Almacen).IsFixedLength();
            entity.Property(e => e.BaseDato).IsFixedLength();
            entity.Property(e => e.CoSucu).IsFixedLength();
            entity.Property(e => e.CoTran).IsFixedLength();
            entity.Property(e => e.CoUsIn).IsFixedLength();
            entity.Property(e => e.CodRecosteo).IsFixedLength();
            entity.Property(e => e.Contab).IsFixedLength();
            entity.Property(e => e.FormaPag).IsFixedLength();
            entity.Property(e => e.Logo).IsFixedLength();
            entity.Property(e => e.Moneda).IsFixedLength();
            entity.Property(e => e.Nomina).IsFixedLength();
            entity.Property(e => e.Proceden).IsFixedLength();
            entity.Property(e => e.Rif).IsFixedLength();
        });

        modelBuilder.Entity<EmpresaParam>(entity =>
        {
            entity.Property(e => e.Nombre).IsFixedLength();
            entity.Property(e => e.Tipo).IsFixedLength();

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.EmpresaParams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_Params_Empresas");
        });

        modelBuilder.Entity<Gcompra>(entity =>
        {
            entity.Property(e => e.Almacen).IsFixedLength();
            entity.Property(e => e.Bl)
                .HasDefaultValueSql("(space((0)))")
                .IsFixedLength();
            entity.Property(e => e.Categoria).IsFixedLength();
            entity.Property(e => e.CoUsuario).IsFixedLength();
            entity.Property(e => e.Empresa).IsFixedLength();
            entity.Property(e => e.FecOdcGenerada).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Linea).IsFixedLength();
            entity.Property(e => e.Procedenci).IsFixedLength();
            entity.Property(e => e.Segmento).IsFixedLength();
            entity.Property(e => e.Sublinea).IsFixedLength();
        });

        modelBuilder.Entity<GcomprasDetalle>(entity =>
        {
            entity.HasKey(e => e.IdProcDetalle).HasName("PK_Gcompras_Procura_Detalle");

            entity.Property(e => e.Codigo).IsFixedLength();
            entity.Property(e => e.Comentario).IsFixedLength();
            entity.Property(e => e.Descripcion).IsFixedLength();
            entity.Property(e => e.Modelo)
                .HasDefaultValueSql("(space((0)))")
                .IsFixedLength();
            entity.Property(e => e.UltUsMod)
                .HasDefaultValueSql("(space((0)))")
                .IsFixedLength();

            entity.HasOne(d => d.IdGcompraNavigation).WithMany(p => p.GcomprasDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gcompras_Detalle_Gcompras");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
