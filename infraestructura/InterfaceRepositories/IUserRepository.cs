using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;

namespace infraestructura.InterfaceRepositories
{
    public interface IUserRepository
    {
        Task<Usuario> BuscaUsuario(Usuario us);
        Task<bool> CreaUsuarioAsync(Usuario us);
    }
}
