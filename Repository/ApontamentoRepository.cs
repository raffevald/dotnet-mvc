using dotnet_mvc.Repository.Interfaces;
using Dapper;

namespace dotnet_mvc.Repository;

public class ApontamentoRepository : IApontamentoRepository {

  // private readonly Dbconnection _dBConnection;
  // string ConnectionString = "Server=127.0.0.1; Port=7000; User Id=postgres; Password=Raff-Nami-2078; Database=dotnet-mvc;";
  // public ApontamentoRepository(Dbconnection dBConnection) {
  //   _dBConnection = dBConnection;
  // }

  MySql.Data.MySqlClient.MySqlConnection conn;
  string ConnectionString = "server=127.0.0.1:3306; uid=root;" + "pwd=root; database=dotnet-mvc";


  public Task<IActionResult> ReadAllApontamento(Apontamento apontamento) {
    // IDbConnetion Conn;
    // NpgsqlConnection Conn;
  
    try {
      string selectQuery = "SELECT * FROM fase;";
      // Conn = new NpgsqlConnection(ConnectionString);
      // Conn.Open();
      // var dados = Conn.Execute(selectQuery, apontamento);
      // return dados;

      conn = new MySql.Data.MySqlClient.MySqlConnection();
      conn.ConnectionString = ConnectionString;
      conn.Open();
      var dados =  conn.Execute(selectQuery);
    } catch {
      throw new NotImplementedException();
    }

    throw new NotImplementedException();
  }
}