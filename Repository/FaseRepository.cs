namespace dotnet_mvc.Repository;

public class FaseRepository : IFaseRepository {

  private readonly DbContextAplication _dbContext;
  public FaseRepository(DbContextAplication dbContext) {
    _dbContext = dbContext;
  }

  public async Task<IEnumerable<Fase>> GetAllFases() {
    return await _dbContext.fase!.ToListAsync();
  }
}
