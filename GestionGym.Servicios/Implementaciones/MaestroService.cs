using AutoMapper;
using GestionGym.Comun;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Repositorios.Interfaces;
using GestionGym.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Implementaciones
{
    public class MaestroService : IMaestroService
    {
        private readonly IMaestroRepository _repository;
        private readonly IMapper _mapper;
        public MaestroService(IMaestroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<DetalleMaestroResponse>> ObtenerDetalleMaestroByCodigo(ListaDetalleMaestroRequest request)
        {
            var respuesta = new PaginationResponse<DetalleMaestroResponse>();
            try
            {
                var resultado = await _repository.ObtenerDetalleMaestroByCodigo(request.codigoMaestro, request.Pagina, request.Filas);
                respuesta.Collection = _mapper.Map<List<DetalleMaestroResponse>>(resultado.collection);
                respuesta.TotalRegistros = resultado.total;
                respuesta.TotalPaginas = Utils.CalcularPaginacion(resultado.total, request.Filas);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Hubo un error al listar el detalle del maestro {request.codigoMaestro}: {ex.Message}";
            }
            return respuesta;
        }
    }
}
