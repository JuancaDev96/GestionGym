using GestionGym.Dto.Request.Maestros;
using GestionGym.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestrosController : ControllerBase
    {
        private readonly IMaestroService _service;
        public MaestrosController(IMaestroService service)
        {
            _service = service;
        }

        [HttpGet("ByCodigo")]
        public async Task<IActionResult> GetByCodigo([FromQuery] ListaDetalleMaestroRequest request)
        {
            var resultado = await _service.ObtenerDetalleMaestroByCodigo(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BusquedaMaestroRequest request)
        {
            var resultado = await _service.ListarMaestros(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MaestroRequest request)
        {
            var resultado = await _service.Registrar(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
