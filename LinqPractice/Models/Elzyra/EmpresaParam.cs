using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

[Table("Empresa_Params")]
[Index("Nombre", "ValB", Name = "IndicieDeMejoraElzyra")]
public partial class EmpresaParam
{
    [Key]
    [Column("id_param")]
    public int IdParam { get; set; }

    [Column("id_empresa")]
    public int IdEmpresa { get; set; }

    [Column("nombre")]
    [StringLength(30)]
    public string Nombre { get; set; } = null!;

    [Column("tipo")]
    [StringLength(10)]
    public string Tipo { get; set; } = null!;

    [Column("val_n", TypeName = "decimal(18, 5)")]
    public decimal? ValN { get; set; }

    [Column("val_c")]
    public string? ValC { get; set; }

    [Column("val_f", TypeName = "datetime")]
    public DateTime? ValF { get; set; }

    [Column("val_b")]
    public bool? ValB { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("EmpresaParams")]
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
