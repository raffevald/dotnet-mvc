namespace dotnet_mvc.Repository;

public class FaseRepository : IFaseRepository {

  public readonly IDbConnection _dBConnection;
  public FaseRepository(
    IDbConnection dBConnection
  ) {
    _dBConnection = dBConnection;
  }

  public async Task<IEnumerable<Fase>> GetAllFases( ) {
    NpgsqlConnection conn = _dBConnection.Execultar();

    try {
      string selectQuery = "SELECT * FROM fase";

      NpgsqlCommand command = new(selectQuery, conn);
      NpgsqlDataReader reader = await command.ExecuteReaderAsync();

      while (await reader.ReadAsync()) {
        Fase fase = ReadFase(reader);
        return (IEnumerable<Fase>)fase;
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
