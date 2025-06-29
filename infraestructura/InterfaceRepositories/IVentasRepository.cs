using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Response;

namespace infraestructura.InterfaceRepositories
{
    public interface IVentasRepository
    {
        Task<IEnumerable<VentasResponseDTO>> ObtenerVentas(int? idUsuario);
    }
}
