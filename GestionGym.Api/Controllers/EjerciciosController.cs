using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjercicioService _servicio;
        public EjerciciosController(IEjercicioService servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EjercicioRequest request)
        {
            var resultado = await _servicio.Registrar(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost("Registrar/Recurso")]
        public async Task<IActionResult> PostRecurso(RecursoEjercicioRequest request)
        {
            var resultado = await _servicio.RegistrarRecurso(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EjercicioRequest request)
        {
            var resultado = await _servicio.Actualizar(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet("Paginacion")]
        public async Task<IActionResult> Get([FromQuery]BusquedaEjerciciosRequest request)
        {
            var resultado = await _servicio.ListarEjerciciosByEstablecimiento(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var resultado = await _servicio.ObtenerPorId(id);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
