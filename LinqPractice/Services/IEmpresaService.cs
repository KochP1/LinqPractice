namespace LinqPractice.Services
{
    public interface IEmpresaService
    {
        string GetDatabase(int id);
        string GetDatabase(string nombre);
        string Bd2K12(string base_dato);
    }
}