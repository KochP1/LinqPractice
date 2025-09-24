namespace LinqPractice.Models.NewFolder
{
    public class EmpresaAlmacenDto
    {
        public string BaseDato { get; set; }
        public string Empresa { get; set; }
        public string AlmacenElzyra { get; set; }
        public string AlmacenProfit { get; set; }
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public decimal Stock { get; set; }
    }

    public class EmpresaAlmacenResponse
    {
        public string BaseDato { get; set; }
        public string DesEmp { get; set; }
        public List<AlmacenInfo> Almacenes { get; set; } = new List<AlmacenInfo>();
    }

    public class AlmacenInfo
    {
        public string CoAlma { get; set; }
        public string DesAlma { get; set; }
        public List<ArticuloStockInfo> ArticulosStock { get; set; } = new List<ArticuloStockInfo>();
    }

    public class ArticuloStockInfo
    {
        public string CoArt { get; set; }
        public string ArtDes { get; set; }
        public decimal Stock { get; set; }
    }
}
