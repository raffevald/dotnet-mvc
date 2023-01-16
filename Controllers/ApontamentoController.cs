using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_mvc.Controllers;

public class ApontamentoController : Controller {
  // private readonly ILogger<ApontamentoController> _logger;
  private readonly IFaseRepository _fase;
  private readonly IApontamentoRepository _apotamentos;

  public ApontamentoController(
    // ILogger<ApontamentoController> logger,
    IFaseRepository fase,
    IApontamentoRepository apotamento
  ) {
    // _logger = logger;
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

  // [NonAction]
  // public void CarregarApontamentos(int id, int streamId, int atividadeId, int faseId, int horas, string observacoes) {
  //   IEnumerable<Apontamento> apontamentos = _apontamentoServico.Buscar(id);
  //   ViewBag.Apontamentos = apontamentos;
  // }

  // private Fase GetFases() {
  //   // var dbUserRoles = new DbUserRoles();
  //   // var dbFases = _fase.GetAllFases();
  //   var dbFases = new Fase();
  //   var fases = dbFases
  //   _fase.GetAllFases()
  //     .Select(x =>
  //       new SelectListItem {
  //           Value = x.UserRoleId.ToString(),
  //           Text = x.UserRole
  //         });

  //   // return new SelectList(roles, "Value", "Text");
  //   return fases;
  // }

  public IActionResult Index() {
    // var data = _apotamentos.ReadAllApontamento();
    var fase = _fase.GetAllFases();
    // ViewBag.Fases = _fase.GetAllFases();
    // ViewData["Fases"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList((System.Collections.IEnumerable)fase, "id", "nome" );
    // List<SelectListItem
    // items = new List<SelectListItem>();
    // items.Add(new SelectListItem { Text = "Action", Value = "0"});
    // ViewBag.Fase = GetFases().Select(c => new SelectListItem() { Text = c.id.ToString(), Value = c.nome}).ToList();

    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error() {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

  // public static List<Fase> GetFases() {
  //   var fases = new List<Fase>() {
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"},
  //     new Fase(){ id=1, nome="Teste"}
  //   };
  //   return fases;
  // }

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
