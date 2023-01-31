using dotnet_mvc.Dtos;

namespace dotnet_mvc.Repository.Interfaces;

public interface IApontamentoRepository {
  Apontamento InsertApotamento(Apontamento apontamento);

  Task<IEnumerable<ApotamentoReadDto>> GetAllApotamentoForMoth(FiltrosSeachApotamento filtros);
}
