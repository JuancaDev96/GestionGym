using AutoMapper;
using GestionGym.Comun;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Entidades;
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
                var resultado = await _repository.ObtenerDetalleMaestroByCodigo(request.codigoMaestro!, request.Pagina, request.Filas);
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

        public async Task<PaginationResponse<DetalleMaestroResponse>> ObtenerDetalleMaestroById(ListaDetalleMaestroRequest request)
        {
            var respuesta = new PaginationResponse<DetalleMaestroResponse>();
            try
            {
                var resultado = await _repository.ObtenerDetalleMaestroByIdMaestro(request.idMaestro, request.Pagina, request.Filas);
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

        public async Task<PaginationResponse<ListaMaestrosResponse>> ListarMaestros(BusquedaMaestroRequest request)
        {
            var respuesta = new PaginationResponse<ListaMaestrosResponse>();
            try
            {
                var resultado = await _repository.ListAsync(

                    predicado: p => p.Estado,
                    selector: p => new ListaMaestrosResponse
                    {
                        Codigo = p.Codigo,
                        Descripcion = p.Descripcion,
                        Id = p.Id,
                        Nombre = p.Nombre
                    },
                    pagina: request.Pagina,
                    filas: request.Filas,
                    orderBy: p => p.Nombre
                );
                respuesta.Collection = resultado.Coleccion;
                respuesta.TotalRegistros = resultado.TotalRegistros;
                respuesta.TotalPaginas = Utils.CalcularPaginacion(resultado.TotalRegistros, request.Filas);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al listar los maestros: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<BaseResponse<MaestroResponse>> BuscarPorId(int idMaestro)
        {
            var respuesta = new BaseResponse<MaestroResponse>();
            try
            {
                var resultado = await _repository.FindByIdAsync(idMaestro);
                respuesta.Data = _mapper.Map<MaestroResponse>(resultado);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al buscar catalogo: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<BaseResponse> Actualizar(MaestroRequest request)
        {
            var respuesta = new BaseResponse();
            try
            {
                var entidad = await _repository.FindByIdAsync(request.Id);
                if(entidad is not null)
                {
                    _mapper.Map(request, entidad);
                    await _repository.UpdateAsync();
                    respuesta.Message = "Catalogo actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al actualizar catalogo: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<BaseResponse<MaestroResponse>> Registrar(MaestroRequest request)
        {
            var respuesta = new BaseResponse<MaestroResponse>();
            try
            {
                var maestro = _mapper.Map<Maestro>(request);    
                var resultado = await _repository.AddAsync(maestro);
                respuesta.Data = _mapper.Map< MaestroResponse>(resultado);
                respuesta.Message = "Catalogo registrado correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al registrar catalogo: {ex.Message}";
            }
            return respuesta;
        }
    }
}
