using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_mvc.Controllers;

public class ApontamentoController : Controller {

  private readonly IFaseRepository _fase;
  private readonly IApontamentoRepository _apotamentos;

  public ApontamentoController(
    IFaseRepository fase,
    IApontamentoRepository apotamento
  ) {
    _fase = fase;
    _apotamentos = apotamento;
  }


  [NonAction]
  public void LoadingFases() {
    IEnumerable<Fase> fases = (IEnumerable<Fase>)_fase.GetAllFases();
    ViewBag.Fases = fases;
  }

  [NonAction]
  public void UploadScheduleNotes() {
    var scheduleNotes = new[] {
      new {Horario = "01:00"},
      new {Horario = "02:00"},
      new {Horario = "03:00"},
      new {Horario = "04:00"},
      new {Horario = "05:00"},
      new {Horario = "06:00"},
      new {Horario = "07:00"},
      new {Horario = "08:00"}
    };
    ViewBag.ScheduleNotes = scheduleNotes;
  }


  [NonAction]
  public async void CarregarFases() {
    var dbFases = await _fase.GetAllFases();

    ViewBag.Fases = dbFases;
  }

  public IActionResult Index ( ) {
    UploadScheduleNotes();
    CarregarFases();

    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

  // [HttpPost]
  // public IActionResult Adicionar(Apontamento apontamento) {
  //   try {
  //     _apontamentoServico.Adicionar(apontamento);
  //     TempData["MensagemSucesso"] = "Apontamento realizado com sucesso";
  //     return RedirectToAction("Adicionar");
  //   } catch (Exception e) {
  //       TempData["MensagemErro"] = $"Não foi possível realizar o apontamento. Detalhe do erro: {e.Message}";
  //       return RedirectToAction("Index");
  //   }
  // }
}
