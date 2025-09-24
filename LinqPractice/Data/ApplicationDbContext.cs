using LinqPractice.Models.Elzyra;
using LinqPractice.Models.Profit;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationDbContext : DbContext
{
    private readonly string _profitConnectionString;
    private readonly string _elzyraConnectionString;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                               IConfiguration configuration)
        : base(options)
    {
        _profitConnectionString = configuration.GetConnectionString("ProfitConnection");
        _elzyraConnectionString = configuration.GetConnectionString("ElzyraConnection");
    }


    public string ProfitDatabaseName { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseSqlServer(_elzyraConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar las entidades de PROFIT para usar diferentes esquemas o nombres dinámicos
        modelBuilder.Entity<SaAlmacen>().ToTable("saAlmacen", schema: "dbo");
        modelBuilder.Entity<SaArticulo>().ToTable("saArticulo", schema: "dbo");
        modelBuilder.Entity<SaStockAlmacen>().ToTable("saStockAlmacen", schema: "dbo");
    }

    // Método para cambiar la base de datos PROFIT según la empresa
    public void SetProfitDatabase(string databaseName)
    {
        ProfitDatabaseName = databaseName;
    }

    // DbSets para ELZYRA
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Almacene> Almacenes { get; set; }
    public DbSet<AspNetUser> AspNetUsers { get; set; }
    public DbSet<AspNetRole> AspNetRoles { get; set; }
    public DbSet<EmpresaParam> Empresa_Params { get; set; }
    public DbSet<ComprasOdc> compras_ODC { get; set; }
    public DbSet<ComprasOdcDetalle> compras_ODC_detalle { get; set; }
    public DbSet<CotizacionCliente> Cotizacion_Cliente { get; set; }
    public DbSet<Gcompra> Gcompras { get; set; }
    public DbSet<GcomprasDetalle> Gcompras_Detalle { get; set; }

    // DbSets para PROFIT
    public DbSet<SaAlmacen> SaAlmacen { get; set; }
    public DbSet<SaArticulo> SaArticulo { get; set; }
    public DbSet<SaStockAlmacen> SaStockAlmacen { get; set; }
}