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
    }
}