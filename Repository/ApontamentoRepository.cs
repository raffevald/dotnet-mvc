namespace dotnet_mvc.Repository;

public class ApontamentoRepository : IApontamentoRepository {

  public readonly IDbConnection _dBConnection;
  public ApontamentoRepository(
    IDbConnection dBConnection
  ) {
    _dBConnection = dBConnection;
  }

  public async Task<Fase> ReadAllApontamento( ) {
    NpgsqlConnection conn = _dBConnection.Execultar();

    try {
      string selectQuery = "SELECT * FROM fase";

      NpgsqlCommand command = new(selectQuery, conn);
      NpgsqlDataReader reader = await command.ExecuteReaderAsync();

      while (await reader.ReadAsync()) {
        Fase fase = ReadFase(reader);
        return fase;
      }
    } catch {
      throw new NotImplementedException();
    }
    throw new NotImplementedException();
  }

  private static Fase ReadFase(NpgsqlDataReader reader) {
    int? id = reader["id"] as int?;
    string? nome = reader["nome"] as string;

    Fase fase = new Fase {
      id = id!.Value,
      nome = nome!,
    };
    return fase;
  }
}
