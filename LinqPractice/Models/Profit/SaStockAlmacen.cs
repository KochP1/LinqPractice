using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Profit;

[PrimaryKey("CoAlma", "CoArt", "Tipo")]
[Table("saStockAlmacen")]
[Index("CoAlma", Name = "IX_saStockAlmacen_co_alma")]
[Index("CoArt", Name = "IX_saStockAlmacen_co_art")]
[Index("Tipo", Name = "Idx_saStockAlmacen_A1")]
public partial class SaStockAlmacen
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
    /// Codigo del articulo
    /// </summary>
    [Key]
    [Column("co_art")]
    [StringLength(30)]
    [Unicode(false)]
    public string CoArt { get; set; } = null!;

    [Key]
    [Column("tipo")]
    [StringLength(4)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    /// <summary>
    /// Stock Actual del Artículo
    /// </summary>
    [Column("stock", TypeName = "decimal(18, 5)")]
    public decimal Stock { get; set; }

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

    [ForeignKey("CoAlma")]
    [InverseProperty("SaStockAlmacens")]
    public virtual SaAlmacen CoAlmaNavigation { get; set; } = null!;

    [ForeignKey("CoArt")]
    [InverseProperty("SaStockAlmacens")]
    public virtual SaArticulo CoArtNavigation { get; set; } = null!;
}
