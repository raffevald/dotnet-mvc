using dotnet_mvc.Dtos;

namespace dotnet_mvc.Controllers;

public class ApontamentoRelatorioController : Controller {
  // private readonly IStreamRepository _stream;
  // private readonly IAtividadesRepository _atividades;
  // private readonly IFaseRepository _fase;
  private readonly IApontamentoRepository _apotamentos;

  public ApontamentoRelatorioController(
    // IStreamRepository stream,
    // IAtividadesRepository atividades,
    // IFaseRepository fase,
    IApontamentoRepository apotamento
  ) {
    // _stream = stream;
    // _atividades = atividades;
    // _fase = fase;
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