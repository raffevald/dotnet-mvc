namespace dotnet_mvc.Repository.Interfaces;

public interface IApontamentoRepository {
  Task<Fase> ReadAllApontamento();
}
