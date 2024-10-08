﻿using System.ComponentModel.DataAnnotations;

namespace achsservicios.Models
{
    public class AccesoFuncViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression("^(\\d{1,8}-[\\dkK])$", ErrorMessage = "El formato de rut no es correcto")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Clave { get; set; }
    }
}
