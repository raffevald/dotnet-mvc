namespace dotnet_mvc.Controllers;

public class ApontamentoController : Controller {
  private readonly ILogger<ApontamentoController> _logger;
  private readonly IApontamentoRepository _apotamentos;

  public ApontamentoController(
    ILogger<ApontamentoController> logger,
    IApontamentoRepository apotamento
  ) {
    _logger = logger;
    _apotamentos = apotamento;
  }

  public IActionResult Index() {
    var data = _apotamentos.ReadAllApontamento();

    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
