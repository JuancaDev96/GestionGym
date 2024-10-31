using GestionGym.Dto.Response.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Request.Maestros;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface IMaestroProxy
    {
        Task<BaseResponse<List<DetalleMaestroResponse>>> ListarDetalleMaestroByCodigo(ListaDetalleMaestroRequest request);
        Task<BaseResponse<List<DetalleMaestroResponse>>> ListarDetalleMaestroByListCodigos(List<string> listCodigos);
        Task<PaginationResponse<DetalleMaestroResponse>> ListaPaginadaDetalleMaestroByCodigo(ListaDetalleMaestroRequest request);
        Task<PaginationResponse<ListaMaestroDetalleResponse>> ListaPaginadaDetalleMaestroByID(ListaDetalleMaestroRequest request);
        Task<PaginationResponse<ListaMaestrosResponse>> ListaPaginadaMaestros(BusquedaMaestroRequest request);
        Task<BaseResponse<MaestroResponse>> GuardarCatalogo(MaestroRequest request);
        Task<BaseResponse<MaestroResponse>> BuscarCatalogoPorId(int idMaestro);
        Task<BaseResponse> ActualizarCatalogo(MaestroRequest request);
        Task<BaseResponse<MaestroDetalleResponse>> GuardarParametroCatalogo(MaestroDetalleRequest request);
        Task<BaseResponse<MaestroDetalleResponse>> BuscarParametroCatalogoPorId(int idMaestroDetalle);
        Task<BaseResponse> ActualizarParametroCatalogo(MaestroDetalleRequest request);
    }
}
