using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Models.Elzyra;

[Table("Cotizacion_Cliente")]
[Index("Empresa", Name = "IDX_CC_A60")]
[Index("Empresa", Name = "IDX_CC_A61")]
[Index("Empresa", Name = "Idx_Cotizacion_Cliente_A1")]
[Index("Empresa", "Consignacion", Name = "Idx_Cotizacion_Cliente_A2")]
[Index("Empresa", "Anulada", "Consignacion", Name = "Idx_Cotizacion_Cliente_A3")]
[Index("Empresa", "Anulada", "Status", Name = "Idx_Cotizacion_Cliente_A4")]
[Index("FactNum", Name = "Idx_Cotizacion_Cliente_A5")]
[Index("Empresa", "IdCiudad", Name = "Idx_Cotizacion_Cliente_A6")]
[Index("Empresa", "Anulada", "Status", "CoUsIn", Name = "Idx_Cotizacion_Cliente_A7")]
[Index("Empresa", Name = "Idx_Tasa_Fact_num_N3")]
[Index("Anulada", "Consignacion", Name = "IndiceDeMejora")]
[Index("Empresa", "FactNum", Name = "Unique_empresa_fact_num", IsUnique = true)]
public partial class CotizacionCliente
{
    [Key]
    [Column("id_cot")]
    public int IdCot { get; set; }

    [Column("empresa")]
    [StringLength(10)]
    public string Empresa { get; set; } = null!;

    [Column("co_cli")]
    [StringLength(16)]
    public string CoCli { get; set; } = null!;

    [Column("co_ven")]
    [StringLength(6)]
    public string CoVen { get; set; } = null!;

    [Column("fec_emis", TypeName = "datetime")]
    public DateTime FecEmis { get; set; }

    [Column("fec_ven", TypeName = "datetime")]
    public DateTime FecVen { get; set; }

    [Column("moneda")]
    [StringLength(6)]
    public string Moneda { get; set; } = null!;

    [Column("condi_pago")]
    [StringLength(6)]
    public string CondiPago { get; set; } = null!;

    [Column("observacion")]
    [StringLength(200)]
    public string Observacion { get; set; } = null!;

    [Column("status")]
    public int Status { get; set; }

    [Column("anulada")]
    public bool Anulada { get; set; }

    [Column("tasa", TypeName = "decimal(18, 5)")]
    public decimal Tasa { get; set; }

    [Column("sub_total", TypeName = "decimal(18, 5)")]
    public decimal? SubTotal { get; set; }

    [Column("iva", TypeName = "decimal(18, 5)")]
    public decimal Iva { get; set; }

    [Column("monto_bruto", TypeName = "decimal(18, 5)")]
    public decimal MontoBruto { get; set; }

    [Column("descuento", TypeName = "decimal(18, 5)")]
    public decimal Descuento { get; set; }

    [Column("monto_neto", TypeName = "decimal(18, 5)")]
    public decimal MontoNeto { get; set; }

    [Column("nombre")]
    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    [Column("rif")]
    [StringLength(12)]
    [Unicode(false)]
    public string Rif { get; set; } = null!;

    [Column("direccion")]
    [StringLength(200)]
    public string Direccion { get; set; } = null!;

    [Column("consignacion")]
    public bool Consignacion { get; set; }

    [Column("migrado")]
    public bool Migrado { get; set; }

    [Column("fact_num")]
    [StringLength(30)]
    public string? FactNum { get; set; }

    [Column("co_us_in")]
    [StringLength(128)]
    public string CoUsIn { get; set; } = null!;

    [Column("fe_us_in", TypeName = "datetime")]
    public DateTime FeUsIn { get; set; }

    [Column("co_us_mo")]
    [StringLength(128)]
    public string CoUsMo { get; set; } = null!;

    [Column("fe_us_mo", TypeName = "datetime")]
    public DateTime FeUsMo { get; set; }

    [Column("email")]
    [StringLength(256)]
    public string Email { get; set; } = null!;

    [Column("fe_env_cot", TypeName = "datetime")]
    public DateTime? FeEnvCot { get; set; }

    [Column("url_env_cot")]
    [StringLength(256)]
    public string? UrlEnvCot { get; set; }

    [Column("co_tran")]
    [StringLength(6)]
    public string CoTran { get; set; } = null!;

    [Column("aprobado")]
    public bool? Aprobado { get; set; }

    [Column("iva_usd", TypeName = "decimal(18, 5)")]
    public decimal? IvaUsd { get; set; }

    [Column("monto_bruto_usd", TypeName = "decimal(18, 5)")]
    public decimal? MontoBrutoUsd { get; set; }

    [Column("monto_neto_usd", TypeName = "decimal(18, 5)")]
    public decimal? MontoNetoUsd { get; set; }

    [Column("url_doc_comp")]
    [StringLength(256)]
    public string? UrlDocComp { get; set; }

    [Column("dir_ent")]
    [StringLength(200)]
    public string? DirEnt { get; set; }

    [Column("descuento_usd", TypeName = "decimal(18, 5)")]
    public decimal? DescuentoUsd { get; set; }

    [Column("sub_total_usd", TypeName = "decimal(18, 5)")]
    public decimal? SubTotalUsd { get; set; }

    [Column("desc_glob", TypeName = "decimal(18, 5)")]
    public decimal? DescGlob { get; set; }

    [Column("orden_cp")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OrdenCp { get; set; }

    [Column("id_ciudad")]
    public int? IdCiudad { get; set; }

    [Column("negociacion_especial")]
    public bool? NegociacionEspecial { get; set; }

    [Column("precio_transporte", TypeName = "decimal(18, 2)")]
    public decimal? PrecioTransporte { get; set; }

    [Column("latitud")]
    public string? Latitud { get; set; }

    [Column("longitud")]
    public string? Longitud { get; set; }
}
