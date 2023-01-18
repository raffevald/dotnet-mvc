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
