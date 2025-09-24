using LinqPractice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElzyraConnection")));
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();

/*
dotnet ef dbcontext scaffold "Server=DESKTOP-S5Q2S88;Database=ELZYRA;Trusted_Connection=true;TrustServerCertificate=True;" 
Microsoft.EntityFrameworkCore.SqlServer -o Models/Elzyra -t Empresas -t Almacenes -t AspNetUsers -t AspNetRoles 
-t Empresa_Params -t compras_ODC -t compras_ODC_detalle -t Cotizacion_Cliente -t Gcompras -t Gcompras_Detalle 
--context-dir Data --context ApplicationDbContext --force

dotnet ef dbcontext scaffold "Server=DESKTOP-S5Q2S88;Database=TOTAL_A;Trusted_Connection=true;TrustServerCertificate=True;" 
Microsoft.EntityFrameworkCore.SqlServer -o Models/Profit -t saAlmacen -t saArticulo -t saStockAlmacen --no-build --force 
--data-annotations 
*/