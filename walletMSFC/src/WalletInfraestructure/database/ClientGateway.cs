using System.Data;
using Dapper;
using WalletCore.entity;
using WalletCore.gateway;

namespace WalletInfraestructure.database
{
    public class ClientGateway : IClientGateway
    {
        public IDbConnection Connection { get; }
        public ClientGateway(IDbConnection connection)
        {
            Connection = connection;
        }

        public Client Get(Guid id)
        {            
            using (var connection = Connection)
            {
                connection.Open();
                var query = $"Select id, name,email, create_at FROM clients WHERE id = {id}";
                return connection.QueryFirst<Client>(query);
            }
        }

        public void Save(Client client)
        {
            using (var connection = Connection)
            {
                string sql = "INSERT INTO clients (id,name,email,created_at) VALUES (@Id, @Name,@Email,@Created_At)";
                connection.Execute(sql, client);
            }
        }
    }
}
