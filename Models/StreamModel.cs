namespace dotnet_mvc.Models;

public class StreamModel {

  public StreamModel(
    int? _id,
    string? _nome
  ) {
    id = _id;
    nome = _nome;
  }
  
  public int? id { get; set; }
  public string? nome { get; set; }
}
