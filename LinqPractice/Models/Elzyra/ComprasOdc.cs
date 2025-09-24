using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

[Table("compras_ODC")]
public partial class ComprasOdc
{
    [Key]
    [Column("id_odc")]
    public int IdOdc { get; set; }

    [Column("id_ac")]
    public int IdAc { get; set; }

    [Column("doc_num_erp")]
    [StringLength(20)]
    [Unicode(false)]
    public string DocNumErp { get; set; } = null!;

    [Column("fec_reg", TypeName = "datetime")]
    public DateTime FecReg { get; set; }

    [Column("prov")]
    [StringLength(30)]
    [Unicode(false)]
    public string Prov { get; set; } = null!;

    [Column("id_moneda")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IdMoneda { get; set; }

    [Column("id_tiponeg")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IdTiponeg { get; set; }

    [Column("incotermCIF")]
    public bool? IncotermCif { get; set; }

    [Column("tasa_negociacion", TypeName = "decimal(18, 5)")]
    public decimal? TasaNegociacion { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("anulada")]
    public bool Anulada { get; set; }

    [Column("migrado")]
    public bool Migrado { get; set; }

    [Column("total_neto", TypeName = "decimal(18, 5)")]
    public decimal TotalNeto { get; set; }

    [Column("fe_us_in", TypeName = "datetime")]
    public DateTime FeUsIn { get; set; }

    [Column("co_us_in")]
    [StringLength(128)]
    [Unicode(false)]
    public string CoUsIn { get; set; } = null!;

    [Column("fe_us_mo", TypeName = "datetime")]
    public DateTime FeUsMo { get; set; }

    [Column("co_us_mo")]
    [StringLength(128)]
    [Unicode(false)]
    public string CoUsMo { get; set; } = null!;

    [Column("ocultar_tml")]
    public bool OcultarTml { get; set; }

    [Column("fecha_nacionalizacion", TypeName = "datetime")]
    public DateTime? FechaNacionalizacion { get; set; }

    [Column("fecha_recepcion", TypeName = "datetime")]
    public DateTime? FechaRecepcion { get; set; }

    [InverseProperty("IdOdcNavigation")]
    public virtual ICollection<ComprasOdcDetalle> ComprasOdcDetalles { get; set; } = new List<ComprasOdcDetalle>();
}
