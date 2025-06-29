using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPrueba.Domain.Entities
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("correo")]
        public string Correo { get; set; }

        [Required]
        [Column("usuario")]
        public string UsuarioNombre { get; set; }

        [Required]
        [Column("rol")]
        public string Rol { get; set; }

        [Required]
        [Column("contrasena")]
        public string Contrasena { get; set; }

        [Column("fecha_alta")]
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        [Column("activo")]
        public bool Activo { get; set; } = true;

        // Relaciones (opcionalmente puedes mantenerlas si están bien mapeadas en EF)
        public ICollection<Venta> VentasCreadas { get; set; }
        public ICollection<Venta> VentasModificadas { get; set; }
    }

}
