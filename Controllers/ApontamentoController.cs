using dotnet_mvc.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_mvc.Controllers;

public class ApontamentoController : Controller {

  private readonly IStreamRepository _stream;
  private readonly IAtividadesRepository _atividades;
  private readonly IFaseRepository _fase;
  private readonly IApontamentoRepository _apotamentos;

  public ApontamentoController(
    IStreamRepository stream,
    IAtividadesRepository atividades,
    IFaseRepository fase,
    IApontamentoRepository apotamento
  ) {
    _stream = stream;
    _atividades = atividades;
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
      new {Horario = "01:00", value = 1},
      new {Horario = "02:00", value = 2},
      new {Horario = "03:00", value = 3},
      new {Horario = "04:00", value = 4},
      new {Horario = "05:00", value = 5},
      new {Horario = "06:00", value = 6},
      new {Horario = "07:00", value = 7},
      new {Horario = "08:00", value = 8}
    };
    ViewBag.ScheduleNotes = scheduleNotes;
  }

  [NonAction]
  public async void CarregarFases() {
    var dbFases = await _fase.GetAllFases();

    ViewBag.Fases = dbFases;
  }

  [NonAction]
  public async void LoadingAllStream() {
    var dbStreans = await _stream.GetAllStream();

    ViewBag.Streans = dbStreans;
  }

  [NonAction]
  public async void LoadingAllAtividadesByStream() {
    var dbAtividadesByStream = await _atividades.GetAllAtividadeByStream(2);
    ViewBag.AtividadesByStream = dbAtividadesByStream;
  }

  public IActionResult Index ( ) {
    LoadingAllStream();
    LoadingAllAtividadesByStream();
    UploadScheduleNotes();
    CarregarFases();

    return View();
  }

  // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  // public IActionResult Error() {
  //   return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  // }

  [HttpPost("apotamento/gravarDados")]
  // [AllowAnonymous]
  public IActionResult Adicionar( [FromBody] Apontamento apontamento) {
    try {
      _apotamentos.InsertApotamento(apontamento);

      return Ok( new { mensagem = "Apotamento inserido com sucesso." });
    } catch {
      throw new NotImplementedException();
    }
  }
}
