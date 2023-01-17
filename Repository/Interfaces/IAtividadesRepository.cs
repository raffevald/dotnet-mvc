namespace dotnet_mvc.Repository.Interfaces;

public interface IAtividadesRepository {
  Task<IEnumerable<AtividadesModel>> GetAllAtividadeByStream(int? idStream);
}
