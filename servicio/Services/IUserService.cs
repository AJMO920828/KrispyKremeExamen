using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;
using Modelo.Response;

namespace Servicio.Services
{
    public interface IUserService
    {
        Task<UsuarioLoginResponseDTO> BuscaUsuario(Usuario us);
        Task<bool> CreaUsuarioAsync(Usuario us);
    }
}
