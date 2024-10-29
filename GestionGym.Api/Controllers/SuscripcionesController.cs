using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Request.Suscripciones;
using GestionGym.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscripcionesController : ControllerBase
    {
        private readonly ISuscripcionService _service;
        public SuscripcionesController(ISuscripcionService service)
        {
            _service = service;
        }

        [HttpGet("Paginacion")]
        public async Task<IActionResult> GetPaginacion([FromQuery] BusquedaSuscripcionRequest request)
        {
            var resultado = await _service.ListarSuscripciones(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SuscripcionRequest request)
        {
            var resultado = await _service.GuardarSuscripcion(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
       
    }
}
