using Microsoft.AspNetCore.Authorization;

namespace dotnet_mvc.Controllers;

[Route("api")]
[ApiController]
public class AtividadesController : Controller {
  private readonly IAtividadesRepository _atividades;
  public AtividadesController(
    IAtividadesRepository atividades
  ) {
    _atividades = atividades;
  }


  [HttpGet("atividades/byStream/{idStream}")]
  [AllowAnonymous]
  public async Task<IActionResult> LoadingAllAtividadesByStream(int? idStream) {
    var dbAtividadesByStream = await _atividades.GetAllAtividadeByStream(idStream);
    return Ok( new { dbAtividadesByStream });
  }
}
