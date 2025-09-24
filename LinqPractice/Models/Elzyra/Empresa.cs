using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

public partial class Empresa
{
    [Key]
    [Column("id_empresa")]
    public int IdEmpresa { get; set; }

    [Column("des_emp")]
    public string DesEmp { get; set; } = null!;

    [Column("base_dato")]
    [StringLength(20)]
    public string BaseDato { get; set; } = null!;

    [Column("fec_registro", TypeName = "datetime")]
    public DateTime FecRegistro { get; set; }

    [Column("co_us_in")]
    [StringLength(128)]
    public string CoUsIn { get; set; } = null!;

    [Column("almacen")]
    [StringLength(10)]
    public string? Almacen { get; set; }

    [Column("co_tran")]
    [StringLength(10)]
    public string? CoTran { get; set; }

    [Column("forma_pag")]
    [StringLength(10)]
    public string? FormaPag { get; set; }

    [Column("moneda")]
    [StringLength(10)]
    public string? Moneda { get; set; }

    [Column("co_sucu")]
    [StringLength(10)]
    public string? CoSucu { get; set; }

    [Column("nomina")]
    [StringLength(30)]
    public string? Nomina { get; set; }

    [Column("contab")]
    [StringLength(10)]
    public string? Contab { get; set; }

    [Column("proceden")]
    [StringLength(10)]
    public string? Proceden { get; set; }

    [Column("Aj_Entrada")]
    [StringLength(10)]
    public string? AjEntrada { get; set; }

    [Column("Aj_Salida")]
    [StringLength(10)]
    public string? AjSalida { get; set; }

    [Column("Cod_recosteo")]
    [StringLength(10)]
    public string? CodRecosteo { get; set; }

    [Column("logo")]
    [StringLength(255)]
    public string? Logo { get; set; }

    [Column("multi_almacen_cf")]
    public bool? MultiAlmacenCf { get; set; }

    [Column("rif")]
    [StringLength(18)]
    [Unicode(false)]
    public string? Rif { get; set; }

    [Column("razon_social")]
    [StringLength(500)]
    public string? RazonSocial { get; set; }

    [Column("dir_fiscal")]
    [StringLength(500)]
    public string? DirFiscal { get; set; }

    [Column("telefono")]
    [StringLength(50)]
    public string? Telefono { get; set; }

    [Column("respons")]
    [StringLength(500)]
    public string? Respons { get; set; }

    [Column("cod_bar")]
    public bool? CodBar { get; set; }

    [Column("no_reply")]
    [StringLength(60)]
    [Unicode(false)]
    public string? NoReply { get; set; }

    [Column("no_reply_clave")]
    [StringLength(60)]
    [Unicode(false)]
    public string? NoReplyClave { get; set; }

    [Column("rm_alic", TypeName = "decimal(18, 2)")]
    public decimal? RmAlic { get; set; }

    [Column("rm_cantut", TypeName = "decimal(18, 2)")]
    public decimal? RmCantut { get; set; }

    [Column("rm_valut", TypeName = "decimal(18, 2)")]
    public decimal? RmValut { get; set; }

    [Column("rim")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Rim { get; set; }

    [Column("co_ace")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CoAce { get; set; }

    [Column("id_servers")]
    public int IdServers { get; set; }

    [Column("ruta_contab")]
    [Unicode(false)]
    public string? RutaContab { get; set; }

    [InverseProperty("IdEmpresaNavigation")]
    public virtual ICollection<Almacene> Almacenes { get; set; } = new List<Almacene>();

    [InverseProperty("IdEmpresaNavigation")]
    public virtual ICollection<EmpresaParam> EmpresaParams { get; set; } = new List<EmpresaParam>();
}
