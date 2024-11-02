using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Dto.Request.Suscripciones;

namespace GestionGym.Servicios.Interfaces
{
    public interface ISuscripcionService
    {
        Task<PaginationResponse<ListaSuscripcionResponse>> ListarSuscripciones(BusquedaSuscripcionRequest request);
        Task<BaseResponse<DetalleSuscripcionResponse>> ObtenerInformacionSuscripcion(int idSuscripcion);
        Task<BaseResponse<int>> GuardarSuscripcion(SuscripcionRequest request);
        Task<BaseResponse<List<ListaPreciosTipoSuscripcionResponse>>> ListaPreciosTipoSuscripcion(int idTipoSuscripcion);
    }
}
