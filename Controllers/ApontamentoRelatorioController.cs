using dotnet_mvc.Dtos;

namespace dotnet_mvc.Controllers;

public class ApontamentoRelatorioController : Controller {
  private readonly IApontamentoRepository _apotamentos;

  public ApontamentoRelatorioController(
    IApontamentoRepository apotamento
  ) {
    _apotamentos = apotamento;
  }


  [HttpPost("apotamento/listagem")]
  public async Task< IActionResult> seachForApartments( [FromBody] FiltrosSeachApotamento filtros) {
    try {
      var dbApontamentos = await _apotamentos.GetAllApotamentoForMoth(filtros);
      return Ok( new { dbApontamentos });
      
    } catch {
      throw new NotImplementedException();
    }
  }
  public IActionResult Index ( ) {
    
    return View();
  }
}