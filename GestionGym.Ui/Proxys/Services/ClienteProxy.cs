using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Ui.Proxys.Interfaces;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Request.Clientes;

namespace GestionGym.Ui.Proxys.Services
{
    public class ClienteProxy(HttpClient httpClient) : ProxyBase("api/Clientes", httpClient), IClienteProxy
    {
        public async Task<BaseResponse<InformacionClienteResponse>> GetDatosPersonalesById(int id)
        {
            return await SendAsync<BaseResponse<InformacionClienteResponse>>($"{id}");
        }

        public async Task<PaginationResponse<ListaClientesResponse>> GetClientes(BusquedaClientesRequest request)
        {
            return await SendAsync<PaginationResponse<ListaClientesResponse>>($"Paginacion?{QueryStringDto(request)}");
        }

        #region Control Fisico

        public async Task<BaseResponse<List<ListaControlFisicoClienteResponse>>> GetControlFisicoParametros(int idCliente)
        {
            return await SendAsync<BaseResponse<List<ListaControlFisicoClienteResponse>>>($"ControlFisico/{idCliente}");
        }

        public async Task<BaseResponse> GuardarParametroControlFisico(ParametroClienteRequest request)
        {
            var resultado = await SendAsync<ParametroClienteRequest, BaseResponse>(request, HttpMethod.Post, "ControlFisico/Parametro/Registrar");
            return resultado is not null ? resultado : new BaseResponse();
        }

        public async Task<BaseResponse> ActualizarControlFisico(List<ControlFisicoClienteRequest> request)
        {
            var resultado = await SendAsync<List<ControlFisicoClienteRequest>, BaseResponse>(request, HttpMethod.Put, "ControlFisico/actualizar");
            return resultado is not null ? resultado : new BaseResponse();
        }

        #endregion

        #region Historial Medico
        public async Task<BaseResponse<List<ListaHistorialMedicoClienteResponse>>> GetHistorialMedicoParametros(int idCliente)
        {
            return await SendAsync<BaseResponse<List<ListaHistorialMedicoClienteResponse>>>($"HistorialMedico/{idCliente}");
        }

        public async Task<BaseResponse> GuardarParametroHistorialMedico(ParametroClienteRequest request)
        {
            var resultado = await SendAsync<ParametroClienteRequest, BaseResponse>(request, HttpMethod.Post, "HistorialMedico/Parametro/Registrar");
            return resultado is not null ? resultado : new BaseResponse();
        }

        public async Task<BaseResponse> ActualizarHistorialMedico(List<HistorialMedicoClienteRequest> request)
        {
            var resultado = await SendAsync<List<HistorialMedicoClienteRequest>, BaseResponse>(request, HttpMethod.Put, "HistorialMedico/actualizar");
            return resultado is not null ? resultado : new BaseResponse();
        }
        #endregion

        public async Task<BaseResponse<int>> GuardarDatosPersonales(DatosPersonalesRequest request)
        {
            var resultado = await SendAsync<DatosPersonalesRequest, BaseResponse<int>>(request, HttpMethod.Post, "");
            return resultado is not null ? resultado : new BaseResponse<int>();
        }

        public async Task<BaseResponse> ActualizarDatosPersonales(DatosPersonalesRequest request)
        {
            var resultado = await SendAsync<DatosPersonalesRequest, BaseResponse>(request, HttpMethod.Put, "");
            return resultado is not null ? resultado : new BaseResponse();
        }
    }
}
