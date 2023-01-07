namespace dotnet_mvc.Models;

public class Apontamento {
  public int? id { get; set; }
  public DateTime? data { get; set; }
  public string? atividades { get; set; }
  public string? stream { get; set; }
  public string? fase { get; set; }
  public string? horasTrabalhada { get; set; }
  public string? observacao { get; set; }
}
