using AutoMapper;
using GestionGym.Comun;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Request.Suscripciones;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Repositorios.Interfaces;
using GestionGym.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Implementaciones
{
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionRepository _repository;
        private readonly IMapper _mapper;
        public SuscripcionService(ISuscripcionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> GuardarSuscripcion(SuscripcionRequest request)
        {
            var respuesta = new BaseResponse<int>();
            try
            {
                var nuevo = _mapper.Map<Suscripcion>(request);
                var cliente = _mapper.Map<Cliente>(request);
               
                var resultado = await _repository.Registrar(nuevo, cliente, request.FechaInicio, request.IdObjetivo, request.IdNivel);
                respuesta.Message = "Suscripción registrada correctamente";
                respuesta.Data = resultado.Id;
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al guardar suscripción: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<BaseResponse<List<ListaPreciosTipoSuscripcionResponse>>> ListaPreciosTipoSuscripcion(int idTipoSuscripcion)
        {
            var respuesta = new BaseResponse<List<ListaPreciosTipoSuscripcionResponse>>();
            try
            {
                var resultado = await _repository.ListarPreciosTipoSuscripcion(idTipoSuscripcion);
                respuesta.Data = _mapper.Map<List<ListaPreciosTipoSuscripcionResponse>>(resultado);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }

        public async Task<PaginationResponse<ListaSuscripcionResponse>> ListarSuscripciones(BusquedaSuscripcionRequest request)
        {
            var respuesta = new PaginationResponse<ListaSuscripcionResponse>();
            try
            {
                var resultado = await _repository.ListAsync(
                    predicado: p => p.Estado &&
                    (
                        string.IsNullOrEmpty(request.Nombre) ||
                        p.IdclienteNavigation.Nombre.Contains(request.Nombre) ||
                        p.IdclienteNavigation.Apellidos.Contains(request.Nombre)
                    ) &&
                    (
                        string.IsNullOrEmpty(request.Dni) ||
                        p.IdclienteNavigation.Dni!.Contains(request.Dni)
                    ),
                   selector: p => new ListaSuscripcionResponse
                   {
                       Cliente = $"{p.IdclienteNavigation.Nombre} {p.IdclienteNavigation.Apellidos}",
                       DniCliente = p.IdclienteNavigation.Dni!,
                       IdCliente = p.Idcliente,
                       EstadoSuscripcion = p.IdestadosuscripcionParametroNavigation.Valor,
                       FechaRegistro = p.Fecharegistro,
                       IdSuscripcion = p.Id,
                       TipoSuscripcion = p.IdtiposuscripcionParametroNavigation.Valor
                   },
                   pagina : request.Pagina,
                   filas : request.Filas,
                   orderBy: p => p.IdclienteNavigation.Nombre);

                respuesta.Collection = _mapper.Map<List<ListaSuscripcionResponse>>(resultado.Coleccion);
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

    }
}
