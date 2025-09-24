using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

public partial class AspNetUser
{
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [StringLength(256)]
    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockoutEndDateUtc { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    [StringLength(256)]
    public string UserName { get; set; } = null!;

    [Column("id_tipo")]
    [StringLength(128)]
    public string? IdTipo { get; set; }

    [Column("id_rol")]
    [StringLength(128)]
    public string? IdRol { get; set; }

    [Column("nombre_completo")]
    [StringLength(128)]
    public string? NombreCompleto { get; set; }

    public int? TipoProceso { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("AspNetUsers")]
    public virtual AspNetRole? IdRolNavigation { get; set; }
}
