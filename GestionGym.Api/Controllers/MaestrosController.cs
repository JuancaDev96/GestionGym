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

        [HttpGet("ById")]
        public async Task<IActionResult> GetById([FromQuery] ListaDetalleMaestroRequest request)
        {
            var resultado = await _service.ObtenerDetalleMaestroById(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet("{idMaestro:int}")]
        public async Task<IActionResult> GetById(int idMaestro)
        {
            var resultado = await _service.BuscarPorId(idMaestro);
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

        [HttpPut]
        public async Task<IActionResult> Put(MaestroRequest request)
        {
            var resultado = await _service.Actualizar(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet("Detalle/{idMaestroDetalle:int}")]
        public async Task<IActionResult> GetDetalleById(int idMaestroDetalle)
        {
            var resultado = await _service.BuscarDetallePorId(idMaestroDetalle);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost("Detalle/Registrar")]
        public async Task<IActionResult> PostDetalle(MaestroDetalleRequest request)
        {
            var resultado = await _service.RegistrarDetalle(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPut("Detalle/Actualizar")]
        public async Task<IActionResult> PutDetalle(MaestroDetalleRequest request)
        {
            var resultado = await _service.ActualizarDetalle(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
