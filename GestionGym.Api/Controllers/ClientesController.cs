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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _service.ObtenerById(id);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet("Paginacion")]
        public async Task<IActionResult> Get([FromQuery] BusquedaClientesRequest request)
        {
            var resultado = await _service.ListarClientes(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet("ControlFisico/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var resultado = await _service.ListarControlFisicoByIdCliente(id);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost("ControlFisico/Parametro/Registrar")]
        public async Task<IActionResult> Get(ParametroClienteRequest request)
        {
            var resultado = await _service.RegistrarParametroControlFisico(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DatosPersonalesRequest request)
        {
            var resultado = await _service.GuardarDatosPersonales(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DatosPersonalesRequest request)
        {
            var resultado = await _service.ActualizarDatosPersonales(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
