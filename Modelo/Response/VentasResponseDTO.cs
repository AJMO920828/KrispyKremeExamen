using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;

namespace Modelo.Response
{
    public class VentasResponseDTO
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? UsuarioAlta { get; set; }
        public bool Activo { get; set; }
    }
}
