using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using appPrueba.Domain.Entities;
using infraestructura.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Request;
using Servicio.Services;

namespace appPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IVentasService _ventasService;
        public VentasController(ApplicationDbContext context, IVentasService ventasService)
        {
            _context = context;
            _ventasService = ventasService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetVentas()
        {
            var rol = User.FindFirst(ClaimTypes.Role)?.Value;
            int? usuarioId = null;

            if (!string.Equals(rol, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int id))
                {
                    return Unauthorized();
                }
                usuarioId = id;
            }

            var response = await _ventasService.ObtenerVentas(usuarioId);

            return Ok(new
            {
                success = true,
                httpStatus = 200,
                messageResponse = "Lista de ventas.",
                body = response
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CrearVenta(VentaRequestDTO ventaDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized();
            var venta = new Venta
            {
                Descripcion = ventaDto.Descripcion,
                Monto = ventaDto.Monto,
                Fecha = ventaDto.Fecha,
                FechaAlta = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow,
                Activo = true,
                UsuarioAltaId = int.Parse(userIdClaim)
            };
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                success = true,
                httpStatus = 200,
                messageResponse = "Lista de ventas.",
                body = venta
            });
        }
    }
}
