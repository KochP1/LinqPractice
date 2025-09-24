using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Profit;

public partial class TotalAContext : DbContext
{
    public TotalAContext()
    {
    }

    public TotalAContext(DbContextOptions<TotalAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SaAlmacen> SaAlmacens { get; set; }

    public virtual DbSet<SaArticulo> SaArticulos { get; set; }

    public virtual DbSet<SaStockAlmacen> SaStockAlmacens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S5Q2S88;Database=TOTAL_A;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<SaAlmacen>(entity =>
        {
            entity.Property(e => e.CoAlma)
                .IsFixedLength()
                .HasComment("Codigo del almacen");
            entity.Property(e => e.AlmTemp).HasComment("Seleccionable en almacenes temporales de traslado");
            entity.Property(e => e.Campo1).HasComment("Campo Adicional");
            entity.Property(e => e.Campo2).HasComment("Campo Adicional");
            entity.Property(e => e.Campo3).HasComment("Campo Adicional");
            entity.Property(e => e.Campo4).HasComment("Campo Adicional");
            entity.Property(e => e.Campo5).HasComment("Campo Adicional");
            entity.Property(e => e.Campo6).HasComment("Campo Adicional");
            entity.Property(e => e.Campo7).HasComment("Campo Adicional");
            entity.Property(e => e.Campo8).HasComment("Campo Adicional");
            entity.Property(e => e.CoSucuIn)
                .IsFixedLength()
                .HasComment("Codigo de la sucursal donde fue ingresado el registro");
            entity.Property(e => e.CoSucuMo)
                .IsFixedLength()
                .HasComment("Codigo de la sucursal donde fue modificado por ultima vez el registro");
            entity.Property(e => e.CoSucur)
                .IsFixedLength()
                .HasComment("Codigo de la sucursal a la que pertenece");
            entity.Property(e => e.CoUsIn)
                .IsFixedLength()
                .HasComment("Codigo del usuario que ingreso el registro");
            entity.Property(e => e.CoUsMo)
                .IsFixedLength()
                .HasComment("Codigo del usuario que hizo la ultima modificación en el registro");
            entity.Property(e => e.DesAlma).HasComment("Descripción del Almacén");
            entity.Property(e => e.FeUsIn).HasComment("Fecha de insercion del registro");
            entity.Property(e => e.FeUsMo).HasComment("Fecha de la ultima modificacion del registro");
            entity.Property(e => e.Materiales).HasComment("Reservado par futuras implementaciones");
            entity.Property(e => e.Nocompra).HasComment("Restringir para modulo de compras");
            entity.Property(e => e.Noventa).HasComment("Restringir para modulo de ventas");
            entity.Property(e => e.Produccion).HasComment("Reservado par futuras implementaciones");
            entity.Property(e => e.Revisado)
                .IsFixedLength()
                .HasComment("Reservado por el sistema");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("Identificador Unico");
            entity.Property(e => e.Trasnfe)
                .IsFixedLength()
                .HasComment("Reservado por el sistema");
            entity.Property(e => e.Validador)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasComment("Marca de tiempo usada en el control de concurrencia");
        });

        modelBuilder.Entity<SaArticulo>(entity =>
        {
            entity.ToTable("saArticulo", tb =>
                {
                    tb.HasTrigger("TrigEstado_saArticulo");
                    tb.HasTrigger("TrigValidarCampos_saArticulo");
                });

            entity.Property(e => e.CoArt)
                .IsFixedLength()
                .HasComment("Codigo del articulo");
            entity.Property(e => e.Anulado).HasComment("Indica si el registro7documento esta anulado");
            entity.Property(e => e.ArtDes).HasComment("Descripcion del artículo");
            entity.Property(e => e.AuxImp01).HasComment("Aux usodo en migracion para traer ultimo costo");
            entity.Property(e => e.Campo1).HasComment("Campo Adicional");
            entity.Property(e => e.Campo2).HasComment("Campo Adicional");
            entity.Property(e => e.Campo3).HasComment("Campo Adicional");
            entity.Property(e => e.Campo4).HasComment("Campo Adicional");
            entity.Property(e => e.Campo5).HasComment("Campo Adicional");
            entity.Property(e => e.Campo6).HasComment("Campo Adicional");
            entity.Property(e => e.Campo7).HasComment("Campo Adicional");
            entity.Property(e => e.Campo8).HasComment("Campo Adicional");
            entity.Property(e => e.CoCat)
                .IsFixedLength()
                .HasComment("Codigo de Categoria");
            entity.Property(e => e.CoColor)
                .IsFixedLength()
                .HasComment("Código del color relacionado con el artículo");
            entity.Property(e => e.CoLin)
                .IsFixedLength()
                .HasComment("Codigo de Linea");
            entity.Property(e => e.CoReten)
                .IsFixedLength()
                .HasComment("Codigo de concepto de I.S.L.R.");
            entity.Property(e => e.CoSubl)
                .IsFixedLength()
                .HasComment("Codigo de Sub Linea");
            entity.Property(e => e.CoSucuIn)
                .IsFixedLength()
                .HasComment("Codigo de la sucursal donde fue ingresado el registro");
            entity.Property(e => e.CoSucuMo)
                .IsFixedLength()
                .HasComment("Codigo de la sucursal donde fue modificado por ultima vez el registro");
            entity.Property(e => e.CoUbicacion)
                .IsFixedLength()
                .HasComment("Ubicación del Artículo");
            entity.Property(e => e.CoUsIn)
                .IsFixedLength()
                .HasComment("Codigo del usuario que ingreso el registro");
            entity.Property(e => e.CoUsMo)
                .IsFixedLength()
                .HasComment("Codigo del usuario que hizo la ultima modificación en el registro");
            entity.Property(e => e.CodProc)
                .IsFixedLength()
                .HasComment("Codigo de procedencia");
            entity.Property(e => e.Comentario).HasComment("Comentario");
            entity.Property(e => e.DisCen).HasComment("Informacion Contable: cuenta contable, cuenta de gasto, distribucion de centro de costo (formato XML)");
            entity.Property(e => e.FeUsIn).HasComment("Fecha de insercion del registro");
            entity.Property(e => e.FeUsMo).HasComment("Fecha de la ultima modificacion del registro");
            entity.Property(e => e.Feccom).HasComment("Informacion Contable: fecha de procesamiento en contabilidad");
            entity.Property(e => e.FechaInac).HasComment("Fecha en la que fue inhabilitado el producto");
            entity.Property(e => e.FechaReg).HasComment("Fecha en que se registra la información");
            entity.Property(e => e.Garantia).HasComment("Garantia");
            entity.Property(e => e.Generico).HasComment("Indica si el articulo es generico");
            entity.Property(e => e.Item)
                .IsFixedLength()
                .HasComment("Item del Artículo, representa un correlativo para la clasificación al cual pertenece el artículo");
            entity.Property(e => e.LicCapacidad).HasComment("Capacidad del licor");
            entity.Property(e => e.LicGradoAl).HasComment("Grado alcoholico");
            entity.Property(e => e.LicMonIlc).HasComment("Monto del impuesto sobre licores");
            entity.Property(e => e.LicTipo)
                .IsFixedLength()
                .HasComment("Tipo de  Licor");
            entity.Property(e => e.ManejaLote).HasComment("Lote");
            entity.Property(e => e.ManejaLoteVenc).HasComment("Maneja lotes con vencimiento");
            entity.Property(e => e.ManejaSerial).HasComment("Indica si maneja Seriales");
            entity.Property(e => e.MargenMax).HasComment("Porcentaje del margen máximo");
            entity.Property(e => e.MargenMin).HasComment("Porcentaje del margen mínimo");
            entity.Property(e => e.Modelo).HasComment("Modelo, aqui  se puede guardar otra codificación para el artículo.");
            entity.Property(e => e.MontComi).HasComment("Monto comisión");
            entity.Property(e => e.Numcom).HasComment("Informacion Contable: numero de comprobante de contabilidad asociado");
            entity.Property(e => e.Peso).HasComment("Peso");
            entity.Property(e => e.PorcArancel).HasComment("Porcentaje de arancel");
            entity.Property(e => e.PorcMargenMinimo).HasComment("Monto comisión");
            entity.Property(e => e.PrecOm).HasComment("Indica si los precios se manejan en otra moneda.");
            entity.Property(e => e.PuntCli).HasComment("Puntajes para el cliente");
            entity.Property(e => e.PuntVen).HasComment("Puntajes para el vendedor");
            entity.Property(e => e.Ref).HasComment("Referencia, aqui  se puede guardar otra codificación para el artículo.");
            entity.Property(e => e.RelacUnidad).HasComment("Indica el tipo de manejo de unidad que tiene el articulo. 0= Maneja una o multiples unidades (con relación); 1= Maneja dos unidades sin relacion");
            entity.Property(e => e.RetenIvaTercero)
                .IsFixedLength()
                .HasComment("Codigo del proveedor al cual se le va a aplicar la retencion del iva a terceros");
            entity.Property(e => e.Revisado)
                .IsFixedLength()
                .HasComment("Reservado por el sistema");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("Identificador Unico");
            entity.Property(e => e.StockMax).HasComment("Stock máximo a mantener");
            entity.Property(e => e.StockMin).HasComment("Stock mínimo a mantener");
            entity.Property(e => e.StockPedido).HasComment("Punto del Stock para hacer reposiciones");
            entity.Property(e => e.Tipo)
                .IsFixedLength()
                .HasComment("V: Venta, C: Consumo, S: Servicio, F: Fabricacion, M: Materia Prima, N: Material de envase, E: Material de empaque (fijo=ART)");
            entity.Property(e => e.TipoCos)
                .IsFixedLength()
                .HasComment("Tipo de costo que se utiliza para calcular el margen con respecto a los precios.  1: Ultimo Costo, 2: Costo Promedio, 3: Ultimo Costo, OM 4: Costo Promedio, OM 5: Reposicion, 6: Proveedor (fijo=TPC) ");
            entity.Property(e => e.TipoImp)
                .IsFixedLength()
                .HasComment("Tipo de impuesto (1) aplicado. 1: Tasa General, 2: Tasa A1, 3: Tasa A2, 4: Tasa A3, 5: Ventas Exentas, 6: Compras Exentas, 7: Exentos (fijo=ISV)");
            entity.Property(e => e.TipoImp2)
                .IsFixedLength()
                .HasComment("Tipo de impuesto (2) aplicado. 1: Tasa General, 2: Tasa A1, 3: Tasa A2, 4: Tasa A3, 5: Ventas Exentas, 6: Compras Exentas, 7: Exentos (fijo=ISV)");
            entity.Property(e => e.TipoImp3)
                .IsFixedLength()
                .HasComment("Tipo de impuesto (3) aplicado. 1: Tasa General, 2: Tasa A1, 3: Tasa A2, 4: Tasa A3, 5: Ventas Exentas, 6: Compras Exentas, 7: Exentos (fijo=ISV)");
            entity.Property(e => e.Trasnfe)
                .IsFixedLength()
                .HasComment("Reservado por el sistema");
            entity.Property(e => e.Validador)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasComment("Marca de tiempo usada en el control de concurrencia");
            entity.Property(e => e.Volumen).HasComment("Volumen");
        });

        modelBuilder.Entity<SaStockAlmacen>(entity =>
        {
            entity.ToTable("saStockAlmacen", tb => tb.HasTrigger("TrigMovimientoStock_OneSelf"));

            entity.Property(e => e.CoAlma)
                .IsFixedLength()
                .HasComment("Codigo del almacen");
            entity.Property(e => e.CoArt)
                .IsFixedLength()
                .HasComment("Codigo del articulo");
            entity.Property(e => e.Tipo).IsFixedLength();
            entity.Property(e => e.Revisado)
                .IsFixedLength()
                .HasComment("Reservado por el sistema");
            entity.Property(e => e.Stock).HasComment("Stock Actual del Artículo");
            entity.Property(e => e.Trasnfe)
                .IsFixedLength()
                .HasComment("Reservado por el sistema");
            entity.Property(e => e.Validador)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasComment("Marca de tiempo usada en el control de concurrencia");

            entity.HasOne(d => d.CoAlmaNavigation).WithMany(p => p.SaStockAlmacens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_saStockAlmacen_saAlmacen");

            entity.HasOne(d => d.CoArtNavigation).WithMany(p => p.SaStockAlmacens).HasConstraintName("FK_saStockAlmacen_saArticulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
