using GestionGym.Dto.Response.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Request.Maestros;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface IMaestroProxy
    {
        Task<PaginationResponse<DetalleMaestroResponse>> ListarDetalleMaestroByCodigo(ListaDetalleMaestroRequest request);
        Task<PaginationResponse<ListaMaestroDetalleResponse>> ListarDetalleMaestroByID(ListaDetalleMaestroRequest request);
        Task<PaginationResponse<ListaMaestrosResponse>> ListarMaestros(BusquedaMaestroRequest request);
        Task<BaseResponse<MaestroResponse>> GuardarCatalogo(MaestroRequest request);
        Task<BaseResponse<MaestroResponse>> BuscarCatalogoPorId(int idMaestro);
        Task<BaseResponse> ActualizarCatalogo(MaestroRequest request);
        Task<BaseResponse<MaestroDetalleResponse>> GuardarParametroCatalogo(MaestroDetalleRequest request);
        Task<BaseResponse<MaestroDetalleResponse>> BuscarParametroCatalogoPorId(int idMaestroDetalle);
        Task<BaseResponse> ActualizarParametroCatalogo(MaestroDetalleRequest request);
    }
}
