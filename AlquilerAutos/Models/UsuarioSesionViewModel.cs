namespace AlquilerAutos.Models
{
    public class UsuarioSesionViewModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreRol { get; set; } = string.Empty;
    }
}