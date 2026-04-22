namespace AlquilerAutos.Models
{
    public class PaginacionViewModel<T>
    {
        public List<T> Items { get; set; } = new();
        public int PaginaActual { get; set; }
        public int TamPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamPagina);
        public string Texto { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}