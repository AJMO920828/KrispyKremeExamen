﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Response
{
    public class UsuarioLoginResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Token { get; set; }
        public string Rol { get; set; }
        public string Mensaje { get; set; }
    }
}
