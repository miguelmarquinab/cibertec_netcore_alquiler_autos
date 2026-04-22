using System.ComponentModel.DataAnnotations;

namespace AlquilerAutos.Models
{
    public class AutoViewModel
    {
        public int IdAuto { get; set; }

        [Required]
        public string Placa { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Range(2000, 2100)]
        public int Anio { get; set; }

        [Required]
        public string Color { get; set; } = string.Empty;

        [Range(1, 99999)]
        public decimal PrecioPorDia { get; set; }

        [Required]
        public string Estado { get; set; } = "DISPONIBLE";

        [Range(1, int.MaxValue)]
        public int IdMarca { get; set; }

        public string NombreMarca { get; set; } = string.Empty;
        public string? ImagenUrl { get; set; }
        public bool Activo { get; set; }

        public int RowNum { get; set; }
        public int TotalRegistros { get; set; }
    }
}