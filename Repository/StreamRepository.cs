namespace dotnet_mvc.Repository;

public class StreamRepository : IStreamRepository {

  public readonly IDbConnection _dBConnection;
  public StreamRepository(
    IDbConnection dBConnection
  ) {
    _dBConnection = dBConnection;
  }

  public async Task<IEnumerable<StreamModel>> GetAllStream( ) {
    NpgsqlConnection conn = _dBConnection.Execultar();

    List<StreamModel> dbStream = new List<StreamModel>();

    try {
      string selectQuery = "SELECT * FROM stream";

      NpgsqlCommand command = new(selectQuery, conn);
      NpgsqlDataReader reader = await command.ExecuteReaderAsync();

      while (await reader.ReadAsync()) {
        int? id = reader["id"] as int?;
        string? nome = reader["nome"] as string;

        StreamModel stream = new StreamModel(
          id,
          nome
        );

        dbStream.Add(stream);
      }
    } catch {
      throw new NotImplementedException();
    }

    return dbStream;
  }
}
