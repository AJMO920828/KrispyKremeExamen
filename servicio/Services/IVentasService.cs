using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Response;

namespace Servicio.Services
{
    public interface IVentasService
    {
        Task<IEnumerable<VentasResponseDTO>> ObtenerVentas(int? idUsuario);
    }
}
