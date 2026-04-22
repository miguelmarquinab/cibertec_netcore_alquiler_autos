using System.ComponentModel.DataAnnotations;

namespace AlquilerAutos.Models
{
    public class AlquilerViewModel
    {
        public int IdAlquiler { get; set; }

        [Range(1, int.MaxValue)]
        public int IdCliente { get; set; }

        [Range(1, int.MaxValue)]
        public int IdAuto { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; } = DateTime.Today.AddDays(1);

        public int Dias { get; set; }
        public decimal PrecioDia { get; set; }

        [Range(0, 99999)]
        public decimal Garantia { get; set; } = 200;

        public decimal Total { get; set; }

        public string Estado { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }

        public string Cliente { get; set; } = string.Empty;
        public string Auto { get; set; } = string.Empty;
        public string UsuarioRegistro { get; set; } = string.Empty;
    }
}