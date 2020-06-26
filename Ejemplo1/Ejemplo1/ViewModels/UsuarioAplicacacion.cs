using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.ViewModels
{
    public class UsuarioAplicacacion: IdentityUser
    {
        //ahora cambiaremos todas las referencias de identityUser poner usuarioaplicacion
        //Para poner nuestro digamos identityUser personalizado o extender las funcionalidad del entity framework
        public string ayudaPass { get; set; }
    }
}
