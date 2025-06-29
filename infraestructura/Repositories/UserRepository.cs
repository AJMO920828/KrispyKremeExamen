using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;
using Dapper;
using infraestructura.InterfacePersistence;
using infraestructura.InterfaceRepositories;

namespace infraestructura.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        public UserRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<Usuario> BuscaUsuario(Usuario us)
        {
            var query = @"SELECT 
                                id AS Id,
                                nombre AS Nombre,
                                correo AS Correo,
                                usuario AS UsuarioNombre,
                                rol AS Rol,
                                contrasena AS Contrasena,
                                fecha_alta AS FechaAlta,
                                activo AS Activo
                            FROM usuarios
                            WHERE LTRIM(RTRIM(usuario)) = LTRIM(RTRIM(@UsuarioNombre)) 
                            AND LTRIM(RTRIM(contrasena)) = LTRIM(RTRIM(@Contrasena))
                            AND activo = 1";
            var parameters = new
            {
                UsuarioNombre = us.UsuarioNombre,
                Contrasena = us.Contrasena
            };
            using var db = _databaseConnection.CreateConnection();
            var usuario = await db.QueryFirstOrDefaultAsync<Usuario>(query, parameters);
            return usuario;
        }

        public async Task<bool> CreaUsuarioAsync(Usuario us)
        {
            var query = @"INSERT INTO usuarios 
                    (nombre, correo, usuario, contrasena, fecha_alta, activo, rol)
                  VALUES 
                    (@Nombre, @Correo, @UsuarioNombre, @Contrasena, @FechaAlta, @Activo, @Rol)";

            var parameters = new
            {
                Nombre = us.Nombre,
                Correo = us.Correo,
                UsuarioNombre = us.UsuarioNombre,
                Contrasena = us.Contrasena,
                FechaAlta = DateTime.Now,
                Activo = us.Activo,
                Rol = us.Rol
            };

            using var db = _databaseConnection.CreateConnection();
            try
            {
                var result = await db.ExecuteAsync(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                // Puedes loggear el error aquí si tienes un logger
                return false;
            }
        }
    }
}
