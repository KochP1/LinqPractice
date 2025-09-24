using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

[Table("Gcompras_Detalle")]
public partial class GcomprasDetalle
{
    [Key]
    [Column("id_proc_detalle")]
    public int IdProcDetalle { get; set; }

    [Column("id_gcompra")]
    public int IdGcompra { get; set; }

    [Column("codigo")]
    [StringLength(30)]
    public string Codigo { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(150)]
    public string Descripcion { get; set; } = null!;

    [Column("enero", TypeName = "decimal(18, 2)")]
    public decimal Enero { get; set; }

    [Column("febrero", TypeName = "decimal(18, 2)")]
    public decimal Febrero { get; set; }

    [Column("marzo", TypeName = "decimal(18, 2)")]
    public decimal Marzo { get; set; }

    [Column("abril", TypeName = "decimal(18, 2)")]
    public decimal Abril { get; set; }

    [Column("mayo", TypeName = "decimal(18, 2)")]
    public decimal Mayo { get; set; }

    [Column("junio", TypeName = "decimal(18, 2)")]
    public decimal Junio { get; set; }

    [Column("julio", TypeName = "decimal(18, 2)")]
    public decimal Julio { get; set; }

    [Column("agosto", TypeName = "decimal(18, 2)")]
    public decimal Agosto { get; set; }

    [Column("septiembre", TypeName = "decimal(18, 2)")]
    public decimal Septiembre { get; set; }

    [Column("octubre", TypeName = "decimal(18, 2)")]
    public decimal Octubre { get; set; }

    [Column("noviembre", TypeName = "decimal(18, 2)")]
    public decimal Noviembre { get; set; }

    [Column("diciembre", TypeName = "decimal(18, 2)")]
    public decimal Diciembre { get; set; }

    [Column("por_llegar", TypeName = "decimal(18, 2)")]
    public decimal PorLlegar { get; set; }

    [Column("alma_ext", TypeName = "decimal(18, 2)")]
    public decimal AlmaExt { get; set; }

    [Column("actual", TypeName = "decimal(18, 2)")]
    public decimal Actual { get; set; }

    [Column("costo", TypeName = "decimal(18, 2)")]
    public decimal Costo { get; set; }

    [Column("total_ventas", TypeName = "decimal(18, 2)")]
    public decimal TotalVentas { get; set; }

    [Column("sugerido", TypeName = "decimal(18, 2)")]
    public decimal Sugerido { get; set; }

    [Column("comprar", TypeName = "decimal(18, 2)")]
    public decimal Comprar { get; set; }

    [Column("comentario")]
    [StringLength(100)]
    public string Comentario { get; set; } = null!;

    [Column("marcado")]
    public bool Marcado { get; set; }

    [Column("modificado")]
    public bool Modificado { get; set; }

    [Column("ult_us_mod")]
    [StringLength(128)]
    public string UltUsMod { get; set; } = null!;

    [Column("modelo")]
    [StringLength(30)]
    public string? Modelo { get; set; }

    [ForeignKey("IdGcompra")]
    [InverseProperty("GcomprasDetalles")]
    public virtual Gcompra IdGcompraNavigation { get; set; } = null!;
}
