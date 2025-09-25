using LinqPractice.Models.Elzyra;
using LinqPractice.Models.NewFolder;
using LinqPractice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Xml.Linq;

namespace LinqPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IEmpresaService empresaService;

        public EmpresaController(ApplicationDbContext context, IEmpresaService empresaService)
        {
            this.context = context;
            this.empresaService = empresaService;
        }

        [HttpGet("empresa_almacen/{base_dato}")]
        public async Task<IActionResult> GetEmpresaAlmacen(string base_dato)
        {
           var bd2k12 = empresaService.Bd2K12(base_dato);

            if (string.IsNullOrEmpty(bd2k12))
                return NotFound($"No se encontró base de datos para: {base_dato}");

            var sql = $@"
            SELECT e.base_dato as BaseDato, 
                   e.des_emp as Empresa, 
                   a.co_alma as AlmacenElzyra, 
                   sa.des_alma as AlmacenProfit, 
                   art.co_art as CodigoArticulo, 
                   art.art_des as DescripcionArticulo, 
                   st.stock as Stock  
            FROM Empresas e 
            LEFT JOIN Almacenes a ON e.id_empresa = a.id_empresa
            INNER JOIN [{bd2k12}].dbo.saAlmacen sa ON sa.co_alma = a.co_alma
            INNER JOIN [{bd2k12}].dbo.saStockAlmacen st ON a.co_alma = st.co_alma 
            INNER JOIN [{bd2k12}].dbo.saArticulo art ON st.co_art = art.co_art
            WHERE st.stock > 0 AND e.base_dato = '{base_dato}'";

            var resultado = await context.Database
                .SqlQueryRaw<EmpresaAlmacenDto>(sql)
                .AsNoTracking()
                .ToListAsync();

            var linq = resultado.GroupBy(x => new { x.BaseDato, x.Empresa })
                       .Select(g => new EmpresaAlmacenResponse
                       {
                           BaseDato = g.Key.BaseDato,
                           DesEmp = g.Key.Empresa,
                           Almacenes = g.GroupBy(a => new { a.AlmacenElzyra, a.AlmacenProfit })
                            .Select(ga => new AlmacenInfo
                            {
                                CoAlma = ga.Key.AlmacenElzyra,
                                DesAlma = ga.Key.AlmacenProfit,
                                ArticulosStock = ga.Select(art => new ArticuloStockInfo
                                {
                                    CoArt = art.CodigoArticulo,
                                    ArtDes = art.DescripcionArticulo,
                                    Stock = art.Stock
                                }).Take(50).ToList()
                            }).ToList()
                       }
                       ).ToList();

            return Ok(linq);
        }

        [HttpGet("analista_serv_cli")]
        public async Task<IActionResult> GetAnalista()
        {

            var usuario = await context.AspNetUsers
                .AsNoTracking()
                .Include(x => x.IdRolNavigation)
                .Where(x => x.IdRol == "cfc893a3-e01a-400c-a25c-a58d01da061c")
                .OrderBy(x => x.UserName)
                .Skip(15)
                .ToListAsync();

            var usuarioDto = (from u in usuario
                             orderby u.NombreCompleto
                             select new
                             {
                                 Id = u.Id.Trim(),
                                 Email = u.Email,
                                 Nombre = u.NombreCompleto.Trim(),
                                 Rol = u.IdRolNavigation.Name
                             }).Take(18);
            return Ok(usuarioDto);
        }

        [HttpGet("cotizaciones-promedio-superiores")]
        public async Task<IActionResult> GetCotizacionesSuperioresAlPromedio()
        {
            try
            {
                var cotizaciones = await context.Cotizacion_Cliente
                    .AsNoTracking()
                    .Where(c => !c.Anulada && c.MontoNetoUsd.HasValue && c.MontoNetoUsd > 0)
                    .ToListAsync();

                if (!cotizaciones.Any())
                    return NotFound("No se encontraron cotizaciones válidas");

                var resultado = cotizaciones
                    .GroupBy(c => c.Empresa)
                    .Select(grupo => new
                    {
                        Empresa = grupo.Key,
                        PromedioUsd = grupo.Average(c => c.MontoNetoUsd.Value),
                        Cotizaciones = grupo.ToList()
                    })
                    .ToDictionary(
                        g => $"{g.Empresa.Trim()}-{g.PromedioUsd:F2}",

                        g => g.Cotizaciones
                            .Where(c => c.MontoNetoUsd >= g.PromedioUsd)
                            .OrderBy(c => Math.Abs(c.MontoNetoUsd.Value - g.PromedioUsd))
                            .ThenByDescending(c => c.FecEmis)
                            .Take(20)
                            .Select(c => new
                            {
                                c.IdCot,
                                FactNum = c.FactNum.Trim(),
                                c.FecEmis,
                                CoCli = c.CoCli.Trim(),
                                Nombre = c.Nombre.Trim(),
                                MontoNetoUsd = c.MontoNetoUsd.Value,
                                DiferenciaConPromedio = c.MontoNetoUsd.Value - g.PromedioUsd,
                                PorcentajeSobrePromedio = (c.MontoNetoUsd.Value / g.PromedioUsd * 100) - 100
                            })
                            .ToList()
                    );

                return Ok(new
                {
                    CotizacionesPorEmpresa = resultado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("compras/{empresa}")]
        public async Task<IActionResult> GetCompras(string empresa)
        {
            var compra = await context.Gcompras
                .AsNoTracking()
                .Include(x => x.GcomprasDetalles.Where(y => y.Costo>2))
                .Where(c => c.Empresa == empresa)
                .ToListAsync();

            var compraDto = from c in compra
                            select new
                            {
                                Id = c.IdGcompra,
                                Fecha_emision = c.FecEmis,
                                Empresa = c.Empresa,
                                Almacen = c.Almacen,
                                Articulos = c.GcomprasDetalles.Select(g => new {
                                    Codigo = g.Codigo,
                                    Descripcion = g.Descripcion,
                                    Costo = g.Costo
                                }).Take(20).ToArray()
                            };

            return Ok(compraDto);
        }

        [HttpGet("ordenes")]
        public async Task<ActionResult> GetComprasOdt()
        {
            var topOdc = await context.compras_ODC
                .AsNoTracking()
                .GroupJoin(
                    context.compras_ODC_detalle,
                    odc => odc.IdOdc,
                    detalle => detalle.IdOdc,
                    (odc, detalles) => new
                    {
                        Odc = odc,
                        TotalCosto = detalles.Sum(d => d.Costo)
                    })
                .OrderByDescending(x => x.TotalCosto)
                .Take(40)
                .Select(x => new
                {
                    x.Odc.IdOdc,
                    x.Odc.Prov,
                    x.Odc.IdMoneda,
                    x.Odc.FecReg,
                    x.Odc.TasaNegociacion,
                    x.Odc.TotalNeto,
                    x.TotalCosto
                }).ToListAsync();

            return Ok(topOdc);
        } 
    }
}
