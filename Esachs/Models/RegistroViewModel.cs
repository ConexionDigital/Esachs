using System.ComponentModel.DataAnnotations;

namespace achsservicios.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "No corresponde el formato de correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(18, ErrorMessage = "La {0} debe tener al menos {2} caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
