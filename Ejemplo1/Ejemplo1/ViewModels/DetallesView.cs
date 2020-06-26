using Ejemplo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.ViewModels
{
    public class DetallesView
    {

        //definir propiedaes que queremos mostar en la vista
        public string titulo { get; set; }
        public string subTitulo { get; set; }
        public Amigo amigo { get; set; }
    }
}
