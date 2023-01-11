namespace dotnet_mvc.Controllers;

public class ApontamentoController : Controller {
  private readonly ILogger<ApontamentoController> _logger;
  private readonly IApontamentoRepository _apotamentos;
  // private readonly IFaseRepository _fase;
  public ApontamentoController(
    ILogger<ApontamentoController> logger,
    // IFaseRepository fase
    IApontamentoRepository apotamento
  ) {
    _logger = logger;
    // _fase = fase;
    _apotamentos = apotamento;
  }

  public IActionResult Index() {
    var data = _apotamentos.ReadAllApontamento();
    // var fases = _fase.GetAllFases();

    return View();
  }

  // public IActionResult Privacy() {
  //   return View();
  // }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
