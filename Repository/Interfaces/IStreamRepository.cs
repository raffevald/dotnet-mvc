namespace dotnet_mvc.Repository.Interfaces;

public interface IStreamRepository {
  Task<IEnumerable<StreamModel>> GetAllStream();
}
