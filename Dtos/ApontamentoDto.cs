using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Dtos;

public class ApontamentoCreateDto {
  public string? data { get; set; }
  public string? SelectedStreamId { get; set; }
  public string? SelectedAtividadesId { get; set; }
  public string? SelectedFaseId { get; set; }
  public string? horasTrabalhada { get; set; }
  public string? observacao { get; set; }
}

public class ApotamentoReadDto {
  public ApotamentoReadDto(
    int? _id,
    DateTime? _dataapotamento,
    string? _observacao,
    int? _horastrabalhada,
    string? _stream,
    string? _fase,
    string? _atividade
  ) {
    id = _id;
    dataapotamento = _dataapotamento;
    observacao = _observacao;
    horastrabalhada = _horastrabalhada;
    stream = _stream;
    fase = _fase;
    atividade = _atividade;
  }

  public int? id { get; set;}
  public DateTime? dataapotamento { get; set; }
  public string? observacao { get; set; }
  public int? horastrabalhada { get; set; }
  public string? stream { get; set; }
  public string? fase { get; set; }
  public string? atividade { get; set; }
}

public class FiltrosSeachApotamento {
  public string? dataInicio { get; set; }
  public string? dataFim { get; set; }
}
