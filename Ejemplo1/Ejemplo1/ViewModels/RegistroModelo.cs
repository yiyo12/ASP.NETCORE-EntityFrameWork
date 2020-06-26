using Ejemplo1.Utilidad;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.ViewModels
{
    public class RegistroModelo
    {
        [Required(ErrorMessage ="Email obligatorio")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Formato Incorrecto")]
        [EmailAddress]
        [Remote(action: "comprobarEmail", controller: "Cuentas")]
        [ValidadorNombreUsuario(usuario: "joder",ErrorMessage = "Nombre no permitido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "password obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repetir Password" )]
        [Compare("Password",ErrorMessage = "La password y la password de confimacion no coiciden")]
        public string PasswordValidar { get; set; }

        //creamos un campo para poder utilizar el nuevo campo que creamos en la tabla de base de datos
        [Display(Name = "recordar contrasena")]
        public string ayudaPass { get; set; }

    }
}
