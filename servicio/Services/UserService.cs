using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;
using infraestructura.InterfaceRepositories;
using infraestructura.Repositories;
using Modelo.Response;

namespace Servicio.Services
{
    public class UserService : IUserService
    {
        private readonly JwtService _jwtService;
        private readonly IUserRepository _userRepository;
        public UserService(JwtService jwtService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        public async Task<UsuarioLoginResponseDTO> BuscaUsuario(Usuario us)
        {
            Usuario usuario = await _userRepository.BuscaUsuario(us);
            if (usuario == null)
                return null; // o lanza excepción si aplica

            string token = _jwtService.GenerateToken(usuario.Rol, usuario.UsuarioNombre, usuario.Id);

            return new UsuarioLoginResponseDTO
            {
                Id = usuario.Id,
                Nombre = usuario.UsuarioNombre,
                Token = token,
                Rol =usuario.Rol
            };
        }

        public async Task<bool> CreaUsuarioAsync(Usuario us)
        {
            return await _userRepository.CreaUsuarioAsync(us);
        }
    }
}
