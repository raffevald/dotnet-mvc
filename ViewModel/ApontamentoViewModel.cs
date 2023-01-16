using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models;

public class ApontamentoViewModel {

  [Display(Name ="Código")]
  [Column("id")]
  public int? id { get; set; }
  

  public int? faseId { get; set; }
  public IEnumerable<Fase>? fases { get; set; }


  [Display(Name ="Data")]
  public DateTime? data { get; set; }


  [Display(Name ="Atividades")]
  public string? atividades { get; set; }
  public string? stream { get; set; }
  

  public string? horasTrabalhada { get; set; }
  public string? observacao { get; set; }

}
