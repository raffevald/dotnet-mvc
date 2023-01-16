namespace dotnet_mvc.Models;

public class Fase {

  public int? id { get; set; }
  public string? nome { get; set; }

  public Fase(
    int? _id,
    string? _nome
  ) {
    id = _id;
    nome = _nome;
  }
}
