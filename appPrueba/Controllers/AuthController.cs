using appPrueba.Domain.Entities;
using infraestructura.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Request;
using Modelo.Response;
using Servicio.Services;

namespace appPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;

        public AuthController(IUserService userService, ApplicationDbContext context)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var usuario = await _userService.BuscaUsuario(new Usuario { UsuarioNombre = request.Usuario, Contrasena = request.Contrasena });
            if (usuario != null)
            {
                return Ok(new GenericResponseDTO<UsuarioLoginResponseDTO>()
                {
                    Body = usuario,
                    Success = true,
                    HttpStatus = 200,
                    MessageResponse = "Usuario encontrado."
                });
            }
            return Ok(new GenericResponseDTO<UsuarioLoginResponseDTO>()
            {
                Body = new UsuarioLoginResponseDTO { Mensaje = "Usuario o contraseña incorrectos." },
                Success = false,
                HttpStatus = 400,
                MessageResponse = "Usuario o contraseña incorrectos."
            });
        }

        [HttpGet("usuarios")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> usuarios()
        {
            List<Usuario> lista = await _context.Usuarios.ToListAsync();
            return Ok(new GenericResponseDTO<List<Usuario>>()
            {
                Body = lista,
                Success = true,
                HttpStatus = 200,
                MessageResponse = "Usuario encontrado."
            });
        }


        [HttpPost("registrarUsuario")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> registrarUsuario([FromBody] UsuarioAltaRequest request)
        {
            Usuario usuario = new Usuario
            {
                Nombre = request.Nombre,
                Correo = request.Correo,
                UsuarioNombre = request.Usuario,
                Rol = request.Rol,
                Contrasena = request.Contrasena,
                FechaAlta = DateTime.Now,
                Activo = true
            };
            var usuarioRegistrado = await _userService.CreaUsuarioAsync(usuario);
            if (usuarioRegistrado)
            {
                return Ok(new GenericResponseDTO<string>()
                {
                    Body = "El registro se guardó con éxito.",
                    Success = true,
                    HttpStatus = 200,
                    MessageResponse = "Éxito."
                });
            }
            return Ok(new GenericResponseDTO<string>()
            {
                Body = "El registro no se pudo guardar. Verifique los datos e intente otra vez.",
                Success = true,
                HttpStatus = 200,
                MessageResponse = "Error."
            });
        }
    }
}

