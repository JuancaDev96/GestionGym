using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Response;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Dto.Request.Suscripciones;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface ISuscripcionProxy
    {
        Task<PaginationResponse<ListaSuscripcionResponse>> GetSuscripciones(BusquedaSuscripcionRequest request);
        Task<BaseResponse<int>> GuardarSuscripcion(SuscripcionRequest request);
    }
}
