using System.Data;

namespace infraestructura.InterfacePersistence
{
    public interface IDatabaseConnection
    {
        public IDbConnection CreateConnection();
    }
}
