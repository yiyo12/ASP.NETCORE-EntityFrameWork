﻿using Ejemplo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.ViewModels
{
    public class EditAmigosModel:CrearAmigoModelo
    {

        public int id { get; set; }


        public string rutaFotoExistente { get; set; }
    }
}
