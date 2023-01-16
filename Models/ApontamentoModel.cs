using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models;

public class Apontamento {

  [Display(Name ="Código")]
  [Column("id")]
  public int? id { get; set; }


  [Display(Name ="Data")]
  public DateTime? data { get; set; }


  [Display(Name ="Atividades")]
  public string? atividades { get; set; }
  public string? stream { get; set; }

  
  // public Fase? fase { get; set; }
  // public IEnumerable<Fase>? fases { get; set; }
  // public int? faseId { get; set; }
  [Required]
  [Display(Name = "Fase")]
  public string? SelectedFaseId { get; set; }
  public IEnumerable<Fase>? Fases { get; set; }


  public string? horasTrabalhada { get; set; }
  public string? observacao { get; set; }

  // public List<Fase>? fases { get; set;}
  // public Stream stream { get; set; }
}
