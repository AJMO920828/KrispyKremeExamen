using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appPrueba.Domain.Entities;
using Dapper;
using infraestructura.InterfacePersistence;
using infraestructura.InterfaceRepositories;
using Modelo.Response;

namespace infraestructura.Repositories
{
    public class VentasRepository: IVentasRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        public VentasRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public async Task<IEnumerable<VentasResponseDTO>> ObtenerVentas(int? idUsuario)
        {
            var query = @"
                SELECT 
                    v.id AS Id,
                    v.descripcion AS Descripcion,
                    v.monto AS Monto,
                    v.fecha AS Fecha,
                    u.usuario AS UsuarioAlta,
                    v.activo AS Activo
                FROM ventas v
                INNER JOIN usuarios u ON u.id = v.usuario_alta
                WHERE (@usuarioId IS NULL OR @usuarioId = 0 OR v.usuario_alta = @usuarioId)
            ";

            var parameters = new
            {
                usuarioId = idUsuario
            };

            using var db = _databaseConnection.CreateConnection();
            var ventas = await db.QueryAsync<VentasResponseDTO>(query, parameters);
            return ventas;
        }
    }
}
