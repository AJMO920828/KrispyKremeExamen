using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infraestructura.InterfaceRepositories;
using Modelo.Response;

namespace Servicio.Services
{
    public class VentasService: IVentasService
    {
        private readonly IVentasRepository _ventasRepository;
        public VentasService(IVentasRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }
        public async Task<IEnumerable<VentasResponseDTO>> ObtenerVentas(int? idUsuario)
        {
            return await _ventasRepository.ObtenerVentas(idUsuario);
        }
    }
}
