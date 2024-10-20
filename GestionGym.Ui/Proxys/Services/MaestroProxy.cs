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

        public async Task<PaginationResponse<ListaMaestrosResponse>> ListarMaestros(BusquedaMaestroRequest request)
        {
            return await SendAsync<PaginationResponse<ListaMaestrosResponse>>($"?{QueryStringDto(request)}");
        }

        public async Task<BaseResponse<MaestroResponse>> GuardarCatalogo(MaestroRequest request)
        {
            var resultado = await SendAsync<MaestroRequest, BaseResponse<MaestroResponse>>(request, HttpMethod.Post, "");
            return resultado is not null ? resultado : new BaseResponse<MaestroResponse>();
        }
    }
}