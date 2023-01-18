using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models;

public class Apontamento {

  // [Display(Name ="Código")]
  [Column("id")]
  public int? id { get; set; }

  // [Display(Name ="Data")]
  public string? data { get; set; }

  // public string? stream { get; set; }
  public int? SelectedStreamId { get; set; }
  

  // [Display(Name ="Atividades")]
  public int? SelectedAtividadesId { get; set; }

  // [Required]
  // [Display(Name = "Fases")]
  public int? SelectedFaseId { get; set; }
  // public Fase? Fases { get; set; }

  public int? horasTrabalhada { get; set; }
  public string? observacao { get; set; }

}
