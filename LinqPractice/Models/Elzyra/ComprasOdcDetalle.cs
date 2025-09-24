using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

[Table("compras_ODC_detalle")]
public partial class ComprasOdcDetalle
{
    [Key]
    [Column("id_odc_detalle")]
    public int IdOdcDetalle { get; set; }

    [Column("id_odc")]
    public int IdOdc { get; set; }

    [Column("co_art")]
    [StringLength(30)]
    [Unicode(false)]
    public string CoArt { get; set; } = null!;

    [Column("co_uni")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoUni { get; set; } = null!;

    [Column("total_art", TypeName = "decimal(18, 2)")]
    public decimal TotalArt { get; set; }

    [Column("pendiente_fabric", TypeName = "decimal(18, 2)")]
    public decimal PendienteFabric { get; set; }

    [Column("en_produccion", TypeName = "decimal(18, 2)")]
    public decimal EnProduccion { get; set; }

    [Column("pendiente_enviar", TypeName = "decimal(18, 2)")]
    public decimal PendienteEnviar { get; set; }

    [Column("pendiente_despachar", TypeName = "decimal(18, 2)")]
    public decimal PendienteDespachar { get; set; }

    [Column("en_transito", TypeName = "decimal(18, 2)")]
    public decimal EnTransito { get; set; }

    [Column("despachado", TypeName = "decimal(18, 2)")]
    public decimal? Despachado { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("calidad")]
    public int Calidad { get; set; }

    [Column("tiempo_fabricacion")]
    public int? TiempoFabricacion { get; set; }

    [Column("costo", TypeName = "decimal(18, 5)")]
    public decimal? Costo { get; set; }

    [Column("descuento", TypeName = "decimal(18, 2)")]
    public decimal Descuento { get; set; }

    [Column("impuesto", TypeName = "decimal(18, 2)")]
    public decimal Impuesto { get; set; }

    [Column("tot_neto", TypeName = "decimal(18, 2)")]
    public decimal TotNeto { get; set; }

    [ForeignKey("IdOdc")]
    [InverseProperty("ComprasOdcDetalles")]
    public virtual ComprasOdc IdOdcNavigation { get; set; } = null!;
}
