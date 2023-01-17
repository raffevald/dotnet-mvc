namespace dotnet_mvc.Repository;

public class AtividadesRepository : IAtividadesRepository {
  public readonly IDbConnection _dBConnection;
  public AtividadesRepository(
    IDbConnection dBConnection
  ) {
    _dBConnection = dBConnection;
  }

  public async Task<IEnumerable<AtividadesModel>> GetAllAtividadeByStream(int? idStream) {
    NpgsqlConnection conn = _dBConnection.Execultar();

    List<AtividadesModel> dbAtividadesByStream = new List<AtividadesModel>();

    try {
      string selectQuery = $"SELECT id, nome FROM atividades WHERE atividades.fk_stream = {idStream};";

      NpgsqlCommand command = new(selectQuery, conn);
      NpgsqlDataReader reader = await command.ExecuteReaderAsync();

      while (await reader.ReadAsync()) {
        int? id = reader["id"] as int?;
        string? nome = reader["nome"] as string;

        AtividadesModel atividadesByStream = new AtividadesModel(
          id,
          nome
        );

        dbAtividadesByStream.Add(atividadesByStream);
      }
    } catch {
      throw new NotImplementedException();
    }

    return dbAtividadesByStream;
  }
}
