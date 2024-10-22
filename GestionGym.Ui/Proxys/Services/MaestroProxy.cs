using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Ui.Proxys.Interfaces;

namespace GestionGym.Ui.Proxys.Services
{
    public class MaestroProxy : ProxyBase, IMaestroProxy
    {
        public MaestroProxy(HttpClient httpClient) :
            base("api/Maestros", httpClient)
        { }

        public async Task<PaginationResponse<DetalleMaestroResponse>> ListarDetalleMaestroByCodigo(ListaDetalleMaestroRequest request)
        {
            return await SendAsync<PaginationResponse<DetalleMaestroResponse>>($"ByCodigo?{QueryStringDto(request)}");
        }

        public async Task<PaginationResponse<ListaMaestroDetalleResponse>> ListarDetalleMaestroByID(ListaDetalleMaestroRequest request)
        {
            return await SendAsync<PaginationResponse<ListaMaestroDetalleResponse>>($"ById?{QueryStringDto(request)}");
        }

        public async Task<PaginationResponse<ListaMaestrosResponse>> ListarMaestros(BusquedaMaestroRequest request)
        {
            return await SendAsync<PaginationResponse<ListaMaestrosResponse>>($"?{QueryStringDto(request)}");
        }

        public async Task<BaseResponse<MaestroResponse>> GuardarCatalogo(MaestroRequest request)
        {
            var resultado = await SendAsync<MaestroRequest, BaseResponse<MaestroResponse>>(request, HttpMethod.Post, "");
            return resultado is not null ? resultado : new BaseResponse<MaestroResponse>();
        }

        public async Task<BaseResponse<MaestroResponse>> BuscarCatalogoPorId(int idMaestro)
        {
            return await SendAsync<BaseResponse<MaestroResponse>>($"{idMaestro}");
        }

        public async Task<BaseResponse> ActualizarCatalogo(MaestroRequest request)
        {
            var resultado = await SendAsync<MaestroRequest, BaseResponse>(request, HttpMethod.Put, "");
            return resultado is not null ? resultado : new BaseResponse();
        }

        public async Task<BaseResponse<MaestroDetalleResponse>> GuardarParametroCatalogo(MaestroDetalleRequest request)
        {
            var resultado = await SendAsync<MaestroDetalleRequest, BaseResponse<MaestroDetalleResponse>>(request, HttpMethod.Post, "Detalle/Registrar");
            return resultado is not null ? resultado : new BaseResponse<MaestroDetalleResponse>();
        }

        public async Task<BaseResponse<MaestroDetalleResponse>> BuscarParametroCatalogoPorId(int idMaestroDetalle)
        {
            return await SendAsync<BaseResponse<MaestroDetalleResponse>>($"Detalle/{idMaestroDetalle}");
        }

        public async Task<BaseResponse> ActualizarParametroCatalogo(MaestroDetalleRequest request)
        {
            var resultado = await SendAsync<MaestroDetalleRequest, BaseResponse>(request, HttpMethod.Put, "Detalle/Actualizar");
            return resultado is not null ? resultado : new BaseResponse();
        }
    }
}