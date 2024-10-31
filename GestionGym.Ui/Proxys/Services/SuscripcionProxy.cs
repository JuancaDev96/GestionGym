using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Ui.Proxys.Interfaces;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Dto.Request.Suscripciones;

namespace GestionGym.Ui.Proxys.Services
{
    public class SuscripcionProxy : ProxyBase, ISuscripcionProxy
    {
        public SuscripcionProxy(HttpClient httpClient) :
            base("api/Suscripciones", httpClient)
        { }

        public async Task<PaginationResponse<ListaSuscripcionResponse>> GetSuscripciones(BusquedaSuscripcionRequest request)
        {
            return await SendAsync<PaginationResponse<ListaSuscripcionResponse>>($"Paginacion?{QueryStringDto(request)}");
        }

        public async Task<BaseResponse<List<ListaPreciosTipoSuscripcionResponse>>> ListarPreciosTipoSuscripcion(int idTipoSuscripcion)
        {
            return await SendAsync<BaseResponse<List<ListaPreciosTipoSuscripcionResponse>>>($"ListaPrecios/{idTipoSuscripcion}");
        }

        public async Task<BaseResponse<int>> GuardarSuscripcion(SuscripcionRequest request)
        {
            var resultado = await SendAsync<SuscripcionRequest, BaseResponse<int>>(request, HttpMethod.Post, "");
            return resultado is not null ? resultado : new BaseResponse<int>();
        }

      
    }
}
