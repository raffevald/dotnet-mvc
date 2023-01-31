using dotnet_mvc.Dtos;

namespace dotnet_mvc.Repository;

public class ApontamentoRepository : IApontamentoRepository {

  public readonly IDbConnection _dBConnection;
  public ApontamentoRepository(
    IDbConnection dBConnection
  ) {
    _dBConnection = dBConnection;
  }

  public Apontamento InsertApotamento(Apontamento apontamento) {
    NpgsqlConnection conn = _dBConnection.Execultar();

    try {
      string insertQuery = $"INSERT INTO apontamentos( data_atividade, horastrabalhada, observacao, fk_atividades, fk_stream, fk_fase ) VALUES ('{apontamento.data}', {apontamento.horasTrabalhada}, '{apontamento.observacao}', {apontamento.SelectedAtividadesId}, {apontamento.SelectedStreamId}, {apontamento.SelectedFaseId})";
      
      NpgsqlCommand command = new(insertQuery, conn);
      // // NpgsqlDataReader reader = command.ExecuteReader();
      command.ExecuteNonQuery();
      // var cmd = new NpgsqlCommand("INSERT INTO public.apontamentos( data_atividade, horastrabalhada, observacao, fk_atividades, fk_stream, fk_fase) VALUES (@p1), (@p2), (@p3), (@p4), (@p5), (@p6)", conn) {
      //     Parameters = {
      //     new("p1", apontamento.data),
      //     new("p2", apontamento.horasTrabalhada),
      //     new("p3", apontamento.observacao),
      //     new("p4", apontamento.SelectedAtividadesId),
      //     new("p5", apontamento.SelectedStreamId),
      //     new("p6", apontamento.SelectedFaseId )
      //   }
      // };
      // cmd.ExecuteNonQuery();

      return apontamento;
    } catch {
      throw new NotImplementedException();
    }
  }

  public async Task<IEnumerable<ApotamentoReadDto>> GetAllApotamentoForMoth(FiltrosSeachApotamento filtros) {
    NpgsqlConnection conn = _dBConnection.Execultar();

    List<ApotamentoReadDto> dbApontamentos = new List<ApotamentoReadDto>();

    try {
      // string selectQuery = $"SELECT id, nome FROM atividades WHERE atividades.fk_stream = {idStream};";
      string selectQuery = $"SELECT apontamentos.id, apontamentos.data_atividade as dataapotamento, apontamentos.observacao, apontamentos.horastrabalhada, stream.nome as stream, fase.nome as fase, atividades.nome as atividade FROM apontamentos INNER JOIN atividades ON apontamentos.fk_atividades = atividades.id INNER JOIN stream ON apontamentos.fk_stream = stream.id INNER JOIN fase ON apontamentos.fk_fase = fase.id WHERE data_atividade > '{filtros.dataInicio}' AND data_atividade <= '{filtros.dataFim}';";

      NpgsqlCommand command = new(selectQuery, conn);
      NpgsqlDataReader reader = await command.ExecuteReaderAsync();

      while (await reader.ReadAsync()) {
        int? id = reader["id"] as int?;
        DateTime? dataapotamento = reader["dataapotamento"] as DateTime?;
        string? observacao = reader["observacao"] as string;
        int? horastrabalhada = reader["horastrabalhada"] as int?;
        string? stream = reader["stream"] as string;
        string? fase = reader["fase"] as string;
        string? atividade = reader["atividade"] as string;

        ApotamentoReadDto apontamento = new ApotamentoReadDto(
          id,
          dataapotamento,
          observacao,
          horastrabalhada,
          stream,
          fase,
          atividade
        );

        dbApontamentos.Add(apontamento);
      }
    } catch {
      throw new NotImplementedException();
    }

    return dbApontamentos;
  }

}
