using AutoMapper;
using GestionGym.Comun;
using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Ejercicios;
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
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repository;
        private readonly IMapper _mapper;

        public EjercicioService(IEjercicioRepository ejercicioRepository, IMapper mapper)
        {
            _repository = ejercicioRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Actualizar(EjercicioRequest request)
        {
            var respuesta = new BaseResponse();
            try
            {
                var entidad = await _repository.FindByIdAsync(request.Id);
                if (entidad is not null)
                {
                    _mapper.Map(request, entidad);
                    await _repository.UpdateAsync();
                    respuesta.Message = "Ejercicio actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al actualizar catalogo: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<BaseResponse> Registrar(EjercicioRequest request)
        {
            var respuesta = new BaseResponse();
            try
            {
                var ejercicio = _mapper.Map<Ejercicio>(request);
                var rutina = _mapper.Map<List<Rutinaejercicio>>(request.Rutina);
                ejercicio.IdEstablecimiento = Constantes.IdEstablecimientoDefault;
                await _repository.Registrar(ejercicio, rutina);
                respuesta.Message = "Ejercicio registrado correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al registrar catalogo: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<PaginationResponse<ListaEjerciciosResponse>> ListarEjerciciosByEstablecimiento(BusquedaEjerciciosRequest request)
        {
            var respuesta = new PaginationResponse<ListaEjerciciosResponse>();
            try
            {
                var resultado = await _repository.ListAsync(
                    predicado: p => p.Estado && p.IdEstablecimiento == Constantes.IdEstablecimientoDefault,
                    selector: p => new ListaEjerciciosResponse
                    {
                        Id = p.Id,
                        Descripcion = p.Descripcion!,
                        GrupoMuscular = p.IdgrupomuscularParametroNavigation.Valor,
                        IdGrupoMuscular = p.IdGrupoMuscular,
                        Nombre = p.Nombre!,
                        FechaRegistro = p.Fecharegistro
                    },
                    pagina: request.Pagina,
                    filas: request.Filas,
                    orderBy: p => p.Nombre);

                respuesta.Collection = resultado.Coleccion;
                respuesta.TotalRegistros = resultado.TotalRegistros;
                respuesta.TotalPaginas = Utils.CalcularPaginacion(resultado.TotalRegistros, request.Filas);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }

        public async Task<BaseResponse<EjercicioResponse>> ObtenerPorId(int id)
        {
            var respuesta = new BaseResponse<EjercicioResponse>();
            try
            {
                var resultado = await _repository.FindByIdAsync(id);
                if (resultado != null)
                {
                    respuesta.Data = _mapper.Map<EjercicioResponse>(resultado);

                    var rutina = await _repository.ObtenerRutinaByIdEjercicio(id);
                    if (rutina.Any())
                    {
                        respuesta.Data.Rutina.AddRange(_mapper.Map<List<RutinaEjercicioRequest>>(rutina));
                    }
                }
                else
                {
                    respuesta.Success = false;
                    respuesta.Message = "El ejercicio no existe.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
    }
}
