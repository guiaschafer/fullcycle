using System.Data;
using System.Data.SQLite;
using FluentAssertions;
using NSubstitute;
using WalletCore.entity;
using WalletInfraestructure.database;

namespace database;

[TestClass]
public class ClientGatewayTest
{
    public IDbConnection Connection { get; }
    public ClientGatewayTest()
    {
        Connection = new SQLiteConnection("Data Source=:memory:");
    }

    [TestMethod]
    public void Get_ExecuteAsExpected()
    {
        var gateway = new ClientGateway(Connection);
        var client = new Client("teste", "teste@teste.com.br");
        gateway.Save(client);

        var clientFromDb = gateway.Get(client.Id);
        clientFromDb.Name.Should().Be("teste");
    }
}