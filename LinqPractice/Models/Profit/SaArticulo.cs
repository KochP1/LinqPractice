using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Profit;

[Table("saArticulo")]
[Index("Item", Name = "IX_saArticulo_Item")]
[Index("Modelo", Name = "IX_saArticulo_Modelo")]
[Index("Ref", Name = "IX_saArticulo_Ref")]
[Index("ArtDes", Name = "IX_saArticulo_art_des")]
[Index("CoCat", Name = "IX_saArticulo_co_cat")]
[Index("CoColor", Name = "IX_saArticulo_co_color")]
[Index("CoLin", Name = "IX_saArticulo_co_lin")]
[Index("CoSubl", "CoLin", Name = "IX_saArticulo_co_subl")]
[Index("TipoImp", Name = "IX_saArticulo_tipo_imp")]
[Index("Anulado", Name = "Idx_saArticulo_A1")]
[Index("Tipo", Name = "Idx_saArticulo_A2")]
[Index("Tipo", "CoCat", "CodProc", Name = "Idx_saArticulo_A3")]
[Index("Tipo", "Anulado", Name = "Idx_saArticulo_A4")]
[Index("Tipo", "CoCat", "CodProc", "Trasnfe", Name = "Idx_saArticulo_A5")]
[Index("Rowguid", Name = "UK_saArticulo_RowGuid", IsUnique = true)]
public partial class SaArticulo
{
    /// <summary>
    /// Codigo del articulo
    /// </summary>
    [Key]
    [Column("co_art")]
    [StringLength(30)]
    [Unicode(false)]
    public string CoArt { get; set; } = null!;

    /// <summary>
    /// Fecha en que se registra la información
    /// </summary>
    [Column("fecha_reg", TypeName = "smalldatetime")]
    public DateTime FechaReg { get; set; }

    /// <summary>
    /// Descripcion del artículo
    /// </summary>
    [Column("art_des")]
    [StringLength(120)]
    [Unicode(false)]
    public string ArtDes { get; set; } = null!;

    /// <summary>
    /// V: Venta, C: Consumo, S: Servicio, F: Fabricacion, M: Materia Prima, N: Material de envase, E: Material de empaque (fijo=ART)
    /// </summary>
    [Column("tipo")]
    [StringLength(1)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    /// <summary>
    /// Indica si el registro7documento esta anulado
    /// </summary>
    [Column("anulado")]
    public bool Anulado { get; set; }

    /// <summary>
    /// Fecha en la que fue inhabilitado el producto
    /// </summary>
    [Column("fecha_inac", TypeName = "smalldatetime")]
    public DateTime? FechaInac { get; set; }

    /// <summary>
    /// Codigo de Linea
    /// </summary>
    [Column("co_lin")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoLin { get; set; } = null!;

    /// <summary>
    /// Codigo de Sub Linea
    /// </summary>
    [Column("co_subl")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoSubl { get; set; } = null!;

    /// <summary>
    /// Codigo de Categoria
    /// </summary>
    [Column("co_cat")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoCat { get; set; } = null!;

    /// <summary>
    /// Código del color relacionado con el artículo
    /// </summary>
    [Column("co_color")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoColor { get; set; } = null!;

    /// <summary>
    /// Ubicación del Artículo
    /// </summary>
    [Column("co_ubicacion")]
    [StringLength(20)]
    [Unicode(false)]
    public string CoUbicacion { get; set; } = null!;

    /// <summary>
    /// Codigo de procedencia
    /// </summary>
    [Column("cod_proc")]
    [StringLength(6)]
    [Unicode(false)]
    public string? CodProc { get; set; }

    /// <summary>
    /// Item del Artículo, representa un correlativo para la clasificación al cual pertenece el artículo
    /// </summary>
    [Column("item")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Item { get; set; }

    /// <summary>
    /// Modelo, aqui  se puede guardar otra codificación para el artículo.
    /// </summary>
    [Column("modelo")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Modelo { get; set; }

    /// <summary>
    /// Referencia, aqui  se puede guardar otra codificación para el artículo.
    /// </summary>
    [Column("ref")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Ref { get; set; }

    /// <summary>
    /// Indica si el articulo es generico
    /// </summary>
    [Column("generico")]
    public bool Generico { get; set; }

    /// <summary>
    /// Indica si maneja Seriales
    /// </summary>
    [Column("maneja_serial")]
    public bool ManejaSerial { get; set; }

    /// <summary>
    /// Lote
    /// </summary>
    [Column("maneja_lote")]
    public bool ManejaLote { get; set; }

    /// <summary>
    /// Maneja lotes con vencimiento
    /// </summary>
    [Column("maneja_lote_venc")]
    public bool ManejaLoteVenc { get; set; }

    /// <summary>
    /// Porcentaje del margen mínimo
    /// </summary>
    [Column("margen_min", TypeName = "decimal(18, 2)")]
    public decimal MargenMin { get; set; }

    /// <summary>
    /// Porcentaje del margen máximo
    /// </summary>
    [Column("margen_max", TypeName = "decimal(18, 2)")]
    public decimal MargenMax { get; set; }

    /// <summary>
    /// Tipo de impuesto (1) aplicado. 1: Tasa General, 2: Tasa A1, 3: Tasa A2, 4: Tasa A3, 5: Ventas Exentas, 6: Compras Exentas, 7: Exentos (fijo=ISV)
    /// </summary>
    [Column("tipo_imp")]
    [StringLength(1)]
    [Unicode(false)]
    public string TipoImp { get; set; } = null!;

    /// <summary>
    /// Tipo de impuesto (2) aplicado. 1: Tasa General, 2: Tasa A1, 3: Tasa A2, 4: Tasa A3, 5: Ventas Exentas, 6: Compras Exentas, 7: Exentos (fijo=ISV)
    /// </summary>
    [Column("tipo_imp2")]
    [StringLength(1)]
    [Unicode(false)]
    public string? TipoImp2 { get; set; }

    /// <summary>
    /// Tipo de impuesto (3) aplicado. 1: Tasa General, 2: Tasa A1, 3: Tasa A2, 4: Tasa A3, 5: Ventas Exentas, 6: Compras Exentas, 7: Exentos (fijo=ISV)
    /// </summary>
    [Column("tipo_imp3")]
    [StringLength(1)]
    [Unicode(false)]
    public string? TipoImp3 { get; set; }

    /// <summary>
    /// Codigo de concepto de I.S.L.R.
    /// </summary>
    [Column("co_reten")]
    [StringLength(6)]
    [Unicode(false)]
    public string? CoReten { get; set; }

    /// <summary>
    /// Garantia
    /// </summary>
    [Column("garantia")]
    [StringLength(30)]
    [Unicode(false)]
    public string Garantia { get; set; } = null!;

    /// <summary>
    /// Volumen
    /// </summary>
    [Column("volumen", TypeName = "decimal(18, 5)")]
    public decimal Volumen { get; set; }

    /// <summary>
    /// Peso
    /// </summary>
    [Column("peso", TypeName = "decimal(18, 5)")]
    public decimal Peso { get; set; }

    /// <summary>
    /// Stock mínimo a mantener
    /// </summary>
    [Column("stock_min", TypeName = "decimal(18, 5)")]
    public decimal StockMin { get; set; }

    /// <summary>
    /// Stock máximo a mantener
    /// </summary>
    [Column("stock_max", TypeName = "decimal(18, 5)")]
    public decimal StockMax { get; set; }

    /// <summary>
    /// Punto del Stock para hacer reposiciones
    /// </summary>
    [Column("stock_pedido", TypeName = "decimal(18, 5)")]
    public decimal StockPedido { get; set; }

    /// <summary>
    /// Indica el tipo de manejo de unidad que tiene el articulo. 0= Maneja una o multiples unidades (con relación); 1= Maneja dos unidades sin relacion
    /// </summary>
    [Column("relac_unidad")]
    public int RelacUnidad { get; set; }

    /// <summary>
    /// Puntajes para el vendedor
    /// </summary>
    [Column("punt_ven", TypeName = "decimal(18, 2)")]
    public decimal PuntVen { get; set; }

    /// <summary>
    /// Puntajes para el cliente
    /// </summary>
    [Column("punt_cli", TypeName = "decimal(18, 2)")]
    public decimal PuntCli { get; set; }

    /// <summary>
    /// Monto del impuesto sobre licores
    /// </summary>
    [Column("lic_mon_ilc", TypeName = "decimal(18, 2)")]
    public decimal LicMonIlc { get; set; }

    /// <summary>
    /// Capacidad del licor
    /// </summary>
    [Column("lic_capacidad", TypeName = "decimal(18, 3)")]
    public decimal LicCapacidad { get; set; }

    /// <summary>
    /// Grado alcoholico
    /// </summary>
    [Column("lic_grado_al", TypeName = "decimal(10, 2)")]
    public decimal LicGradoAl { get; set; }

    /// <summary>
    /// Tipo de  Licor
    /// </summary>
    [Column("lic_tipo")]
    [StringLength(1)]
    [Unicode(false)]
    public string? LicTipo { get; set; }

    /// <summary>
    /// Indica si los precios se manejan en otra moneda.
    /// </summary>
    [Column("prec_om")]
    public bool PrecOm { get; set; }

    /// <summary>
    /// Comentario
    /// </summary>
    [Column("comentario")]
    [Unicode(false)]
    public string? Comentario { get; set; }

    /// <summary>
    /// Tipo de costo que se utiliza para calcular el margen con respecto a los precios.  1: Ultimo Costo, 2: Costo Promedio, 3: Ultimo Costo, OM 4: Costo Promedio, OM 5: Reposicion, 6: Proveedor (fijo=TPC) 
    /// </summary>
    [Column("tipo_cos")]
    [StringLength(4)]
    [Unicode(false)]
    public string? TipoCos { get; set; }

    /// <summary>
    /// Monto comisión
    /// </summary>
    [Column("porc_margen_minimo", TypeName = "decimal(18, 2)")]
    public decimal PorcMargenMinimo { get; set; }

    [Column("porc_margen_maximo", TypeName = "decimal(18, 2)")]
    public decimal PorcMargenMaximo { get; set; }

    /// <summary>
    /// Monto comisión
    /// </summary>
    [Column("mont_comi", TypeName = "decimal(18, 2)")]
    public decimal MontComi { get; set; }

    /// <summary>
    /// Porcentaje de arancel
    /// </summary>
    [Column("porc_arancel", TypeName = "decimal(18, 2)")]
    public decimal PorcArancel { get; set; }

    /// <summary>
    /// Informacion Contable: numero de comprobante de contabilidad asociado
    /// </summary>
    [Column("numcom")]
    public int? Numcom { get; set; }

    /// <summary>
    /// Informacion Contable: fecha de procesamiento en contabilidad
    /// </summary>
    [Column("feccom", TypeName = "smalldatetime")]
    public DateTime? Feccom { get; set; }

    /// <summary>
    /// Informacion Contable: cuenta contable, cuenta de gasto, distribucion de centro de costo (formato XML)
    /// </summary>
    [Column("dis_cen", TypeName = "xml")]
    public string? DisCen { get; set; }

    /// <summary>
    /// Codigo del proveedor al cual se le va a aplicar la retencion del iva a terceros
    /// </summary>
    [Column("reten_iva_tercero")]
    [StringLength(16)]
    [Unicode(false)]
    public string? RetenIvaTercero { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo1")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo1 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo2")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo2 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo3")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo3 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo4")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo4 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo5")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo5 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo6")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo6 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo7")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo7 { get; set; }

    /// <summary>
    /// Campo Adicional
    /// </summary>
    [Column("campo8")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Campo8 { get; set; }

    /// <summary>
    /// Codigo del usuario que ingreso el registro
    /// </summary>
    [Column("co_us_in")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoUsIn { get; set; } = null!;

    /// <summary>
    /// Codigo de la sucursal donde fue ingresado el registro
    /// </summary>
    [Column("co_sucu_in")]
    [StringLength(6)]
    [Unicode(false)]
    public string? CoSucuIn { get; set; }

    /// <summary>
    /// Fecha de insercion del registro
    /// </summary>
    [Column("fe_us_in", TypeName = "datetime")]
    public DateTime FeUsIn { get; set; }

    /// <summary>
    /// Codigo del usuario que hizo la ultima modificación en el registro
    /// </summary>
    [Column("co_us_mo")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoUsMo { get; set; } = null!;

    /// <summary>
    /// Codigo de la sucursal donde fue modificado por ultima vez el registro
    /// </summary>
    [Column("co_sucu_mo")]
    [StringLength(6)]
    [Unicode(false)]
    public string? CoSucuMo { get; set; }

    /// <summary>
    /// Fecha de la ultima modificacion del registro
    /// </summary>
    [Column("fe_us_mo", TypeName = "datetime")]
    public DateTime FeUsMo { get; set; }

    /// <summary>
    /// Reservado por el sistema
    /// </summary>
    [Column("revisado")]
    [StringLength(1)]
    [Unicode(false)]
    public string? Revisado { get; set; }

    /// <summary>
    /// Reservado por el sistema
    /// </summary>
    [Column("trasnfe")]
    [StringLength(1)]
    [Unicode(false)]
    public string? Trasnfe { get; set; }

    /// <summary>
    /// Marca de tiempo usada en el control de concurrencia
    /// </summary>
    [Column("validador")]
    public byte[] Validador { get; set; } = null!;

    /// <summary>
    /// Identificador Unico
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Aux usodo en migracion para traer ultimo costo
    /// </summary>
    [Column("aux_imp01", TypeName = "decimal(18, 5)")]
    public decimal? AuxImp01 { get; set; }

    [InverseProperty("CoArtNavigation")]
    public virtual ICollection<SaStockAlmacen> SaStockAlmacens { get; set; } = new List<SaStockAlmacen>();
}
