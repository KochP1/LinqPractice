using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

public partial class Gcompra
{
    [Key]
    [Column("id_gcompra")]
    public int IdGcompra { get; set; }

    [Column("fec_emis", TypeName = "datetime")]
    public DateTime FecEmis { get; set; }

    [Column("empresa")]
    [StringLength(30)]
    public string Empresa { get; set; } = null!;

    [Column("almacen")]
    [StringLength(6)]
    public string Almacen { get; set; } = null!;

    [Column("historico_inicio", TypeName = "datetime")]
    public DateTime HistoricoInicio { get; set; }

    [Column("historico_fin", TypeName = "datetime")]
    public DateTime HistoricoFin { get; set; }

    [Column("linea")]
    [StringLength(6)]
    public string Linea { get; set; } = null!;

    [Column("sublinea")]
    [StringLength(6)]
    public string Sublinea { get; set; } = null!;

    [Column("segmento")]
    [StringLength(6)]
    public string Segmento { get; set; } = null!;

    [Column("categoria")]
    [StringLength(6)]
    public string Categoria { get; set; } = null!;

    [Column("procedenci")]
    [StringLength(6)]
    public string Procedenci { get; set; } = null!;

    [Column("fec_culminacion", TypeName = "datetime")]
    public DateTime FecCulminacion { get; set; }

    [Column("co_usuario")]
    [StringLength(128)]
    public string CoUsuario { get; set; } = null!;

    [Column("fec_registro", TypeName = "datetime")]
    public DateTime FecRegistro { get; set; }

    [Column("bl")]
    [StringLength(20)]
    public string Bl { get; set; } = null!;

    [Column("odc_generada")]
    public bool OdcGenerada { get; set; }

    [Column("fec_odc_generada", TypeName = "datetime")]
    public DateTime FecOdcGenerada { get; set; }

    [Column("kg", TypeName = "decimal(18, 2)")]
    public decimal Kg { get; set; }

    [Column("cbm", TypeName = "decimal(18, 2)")]
    public decimal Cbm { get; set; }

    [Column("odc_asignada")]
    public int OdcAsignada { get; set; }

    [Column("id_consolidacion")]
    public int IdConsolidacion { get; set; }

    [Column("view_active")]
    public bool? ViewActive { get; set; }

    [Column("comentario")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Comentario { get; set; }

    [Column("dias_totales")]
    public int DiasTotales { get; set; }

    [InverseProperty("IdGcompraNavigation")]
    public virtual ICollection<GcomprasDetalle> GcomprasDetalles { get; set; } = new List<GcomprasDetalle>();
}
