using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LinqPractice.Models.Profit;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

[Index("CoAlma", "IdEmpresa", Name = "Unique_co_alma_id_empresa", IsUnique = true)]
public partial class Almacene
{
    [Key]
    [Column("id_alma")]
    public int IdAlma { get; set; }

    [Column("co_alma")]
    [StringLength(6)]
    [Unicode(false)]
    public string CoAlma { get; set; } = null!;

    [Column("id_empresa")]
    public int IdEmpresa { get; set; }

    [Column("prioridad")]
    public int Prioridad { get; set; }

    [Column("id_ciudad")]
    public int? IdCiudad { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("Almacenes")]
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    [ForeignKey("co_alma")]
    public ICollection<SaAlmacen> saAlmacenes { get; set; } = [];
}
