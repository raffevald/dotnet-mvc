namespace dotnet_mvc.Repository;

public class ApontamentoRepository {

  private readonly Connection _dBConnection;
  public ApontamentoRepository(Connection dBConnection) {
    _dBConnection = dBConnection;
  }

  public Task<IActionResult> ReadAllApontamento( ) {
    SqlConnection conn = _dBConnection.Execultar();
    Fase fase = new();

    try {
      string selectQuery = "SELECT * FROM fase;";

      SqlCommand command = new(selectQuery, conn);
      SqlDataReader dataReader = command.ExecuteReader();

      while ( dataReader.Read() ) {
        fase = new Fase{
          id = int.Parse(dataReader["id"].ToString()),
          nome = dataReader["nome"].ToString()
        };
      }
    } catch {
      throw new NotImplementedException();
    }

    throw new NotImplementedException();
  }
}