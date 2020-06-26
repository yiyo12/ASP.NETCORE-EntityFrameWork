using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Utilidad
{
    public class ValidadorNombreUsuario: ValidationAttribute
    {
        private readonly string usuario;

        public ValidadorNombreUsuario(string usuario)
        {
            this.usuario = usuario;
        }

        public override bool IsValid(object value)
        {
            Boolean permitido = true;
            if (value.ToString().Contains("joder"))
            {
                permitido = false;
            }
            return permitido;
                
        }
    }
}
