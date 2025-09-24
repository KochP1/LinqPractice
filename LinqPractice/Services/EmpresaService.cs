using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly ApplicationDbContext context;

        public EmpresaService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string GetDatabase(string nombre)
        {
            var sql = "SELECT base_dato FROM Empresas WHERE des_emp = {0}";
            var empresa = context.Empresas
                .FromSqlRaw(sql, nombre)
                .Select(e => e.BaseDato)
                .FirstOrDefault();

            return empresa;
        }

        public string GetDatabase(int id)
        {
            var sql = "SELECT base_dato FROM Empresas WHERE id_empresa = {0}";
            var empresa = context.Empresas
                .FromSqlRaw(sql, id)
                .Select(e => e.BaseDato)
                .FirstOrDefault();

            return empresa;
        }

        public string Bd2K12(string base_dato)
        {
            var result = context.Database
                .SqlQueryRaw<SimpleResult>("SELECT ELZYRA.dbo.func_baseDatos_2k12(NULL, {0}) AS Value", base_dato)
                .AsEnumerable()
                .FirstOrDefault();

            return result?.Value;
        }

        private class SimpleResult
        {
            public string Value { get; set; }
        }
    }
}
