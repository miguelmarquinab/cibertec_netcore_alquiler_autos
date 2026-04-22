using System.ComponentModel.DataAnnotations;

namespace AlquilerAutos.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese el usuario")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese la clave")]
        [DataType(DataType.Password)]
        public string Clave { get; set; } = string.Empty;
    }
}