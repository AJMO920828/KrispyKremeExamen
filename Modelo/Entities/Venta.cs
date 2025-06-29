using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace appPrueba.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        [Column("fecha_alta")]
        public DateTime FechaAlta { get; set; }

        [Column("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; }

        [Column("usuario_alta")]
        public int? UsuarioAltaId { get; set; }

        [Column("usuario_modificacion")]
        public int? UsuarioModificacionId { get; set; }[JsonIgnore]
        public bool Activo { get; set; }

        // Relaciones opcionales
        [JsonIgnore]
        [ForeignKey("UsuarioAltaId")]
        public Usuario UsuarioAlta { get; set; }

        [JsonIgnore]
        [ForeignKey("UsuarioModificacionId")]
        public Usuario UsuarioModificacion { get; set; }
    }
}
