using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Models
{
    public class Amigo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Obligatorio"), MaxLength(100,ErrorMessage = "Excediste los caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name="Email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Formato Incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debes Seleccionar Una Ciudad")]
        public Provincia? Ciudad { get; set; }

        public string rutaFoto { get; set; }

    }
}
