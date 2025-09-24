using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Profit;

[Table("saAlmacen")]
[Index("CoSucur", Name = "IX_saAlmacen_co_sucur")]
[Index("DesAlma", Name = "IX_saAlmacen_des_alma")]
[Index("Rowguid", Name = "UK_saAlmacen_rowguid", IsUnique = true)]
public partial class SaAlmacen
{
    /// <summary>
    /// Codigo del almacen
    /// </summary>
    [Key]
    [Column("co_alma")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoAlma { get; set; } = null!;

    /// <summary>
    /// Descripción del Almacén
    /// </summary>
    [Column("des_alma")]
    [StringLength(60)]
    [Unicode(false)]
    public string DesAlma { get; set; } = null!;

    /// <summary>
    /// Codigo de la sucursal a la que pertenece
    /// </summary>
    [Column("co_sucur")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoSucur { get; set; } = null!;

    /// <summary>
    /// Restringir para modulo de ventas
    /// </summary>
    [Column("noventa")]
    public bool Noventa { get; set; }

    /// <summary>
    /// Restringir para modulo de compras
    /// </summary>
    [Column("nocompra")]
    public bool Nocompra { get; set; }

    /// <summary>
    /// Reservado par futuras implementaciones
    /// </summary>
    [Column("materiales")]
    public bool Materiales { get; set; }

    /// <summary>
    /// Reservado par futuras implementaciones
    /// </summary>
    [Column("produccion")]
    public bool Produccion { get; set; }

    /// <summary>
    /// Seleccionable en almacenes temporales de traslado
    /// </summary>
    [Column("alm_temp")]
    public bool AlmTemp { get; set; }

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

    [InverseProperty("CoAlmaNavigation")]
    public virtual ICollection<SaStockAlmacen> SaStockAlmacens { get; set; } = new List<SaStockAlmacen>();
}
