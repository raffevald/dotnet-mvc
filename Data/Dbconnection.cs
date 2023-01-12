using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace dotnet_mvc.Data;

public class Connection : IDbConnection {
  public NpgsqlConnection Execultar() {
    string ConnectionString = "User Id=postgres; Password='Raff-Nami-2078'; Host=localhost; Port=7000; Database=dotnet-mvc";

    try {
      NpgsqlConnection conn = new(ConnectionString);
      conn.Open();
      return conn;
    } catch {
      throw new NotImplementedException();
    }
  }
}
