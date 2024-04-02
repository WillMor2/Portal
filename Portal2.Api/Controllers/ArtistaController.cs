using Microsoft.AspNetCore.Mvc;
using Portal2.Domain.Interfaces.Services;
using Portal2.Domain.Parameters;

namespace Portal2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistaController : Controller
    {
        public ArtistaController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IArtistaService service,
                                                [FromBody] CreateArtistaParameters parameters)
        {
            var result = await service.Create(parameters);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromServices] IArtistaService service, int idArtista,
                                                [FromBody] UpdateArtistaParameters parameters)
        {
            var result = await service.Update(idArtista, parameters);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetbyId([FromServices] IArtistaService service, int idArtista)
        {
            var result = await service.GetById(idArtista);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] IArtistaService service, int idArtista)
        {
            var result = await service.DeleteById(idArtista);
            return Ok(result);
        }
    }
}
