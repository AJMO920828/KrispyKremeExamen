﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Request
{
    public class UsuarioAltaRequest
    {
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Usuario { get; set; }
    }
}
