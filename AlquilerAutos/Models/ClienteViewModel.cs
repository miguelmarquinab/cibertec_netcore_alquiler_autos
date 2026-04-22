using System.ComponentModel.DataAnnotations;

namespace AlquilerAutos.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        [Required]
        public string Dni { get; set; } = string.Empty;

        [Required]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        public string Apellidos { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public string? Telefono { get; set; }

        [Required]
        public string LicenciaConducir { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}