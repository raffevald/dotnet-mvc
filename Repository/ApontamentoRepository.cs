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
}
