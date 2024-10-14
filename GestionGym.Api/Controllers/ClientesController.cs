using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet("Paginacion")]
        public async Task<IActionResult> Get([FromQuery] BusquedaClientesRequest request)
        {
            var resultado = await _service.ListarClientes(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DatosPersonalesRequest request)
        {
            var resultado = await _service.GuardarDatosPersonales(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
