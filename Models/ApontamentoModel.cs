using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models;

public class Apontamento {

  // [Display(Name ="Código")]
  [Column("id")]
  public int? id { get; set; }

  [Display(Name ="Data")]
  public DateTime? data { get; set; }

  public string? stream { get; set; }

  [Display(Name ="Atividades")]
  public string? atividades { get; set; }

  [Required]
  [Display(Name = "Fases")]
  public int? SelectedFaseId { get; set; }
  public Fase? Fases { get; set; }

  public string? horasTrabalhada { get; set; }
  public string? observacao { get; set; }

}
