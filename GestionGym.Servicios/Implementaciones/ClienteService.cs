using AutoMapper;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Repositorios.Interfaces;
using GestionGym.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Implementaciones
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ListaClientesResponse>> ListarClientes(BusquedaClientesRequest request)
        {
            var respuesta = new PaginationResponse<ListaClientesResponse>();
            try
            {
                var resultado = await _repository.ListarClientes(request);
                respuesta.Collection = _mapper.Map<List<ListaClientesResponse>>(resultado.coleccion);
                respuesta.TotalRegistros = resultado.totalRegistros;
                respuesta.TotalPaginas = resultado.totalPaginas;
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }

        public async Task<BaseResponse<List<ListaControlFisicoClienteResponse>>> ListarControlFisicoByIdCliente(int idCliente)
        {
            var respuesta = new BaseResponse<List<ListaControlFisicoClienteResponse>>();
            try
            {
                var resultado = await _repository.ListarControlFisicoByIdCliente(idCliente);
                respuesta.Data = _mapper.Map<List<ListaControlFisicoClienteResponse>>(resultado);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }

        public async Task<BaseResponse<int>> GuardarDatosPersonales(DatosPersonalesRequest request)
        {
            var respuesta = new BaseResponse<int>();
            try
            {
                var nuevo = _mapper.Map<Cliente>(request);
                var resultado = await _repository.Registrar(nuevo);
                respuesta.Message = "Datos personales registrados correctamente";
                respuesta.Data = resultado.Id;
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = $"Error al guardar datos personales: {ex.Message}";
            }
            return respuesta;
        }
    }
}
