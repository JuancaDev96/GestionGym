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

        [HttpGet("Paginacion")]
        public async Task<IActionResult> Get([FromQuery]BusquedaEjerciciosRequest request)
        {
            var resultado = await _servicio.ListarEjerciciosByEstablecimiento(request);
            return resultado.Success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
