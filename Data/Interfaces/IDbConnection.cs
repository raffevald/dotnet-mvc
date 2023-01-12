namespace dotnet_mvc.Data.Interfaces;

public interface IDbConnection {
  NpgsqlConnection Execultar();
}
