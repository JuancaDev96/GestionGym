using GestionGym.Dto.Response.Maestros;
using GestionGym.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionGym.Dto.Request.Maestros;

namespace GestionGym.Servicios.Interfaces
{
    public interface IMaestroService
    {
        Task<PaginationResponse<DetalleMaestroResponse>> ObtenerDetalleMaestroByCodigo(ListaDetalleMaestroRequest request);
        Task<PaginationResponse<ListaMaestroDetalleResponse>> ObtenerDetalleMaestroById(ListaDetalleMaestroRequest request);
        Task<PaginationResponse<ListaMaestrosResponse>> ListarMaestros(BusquedaMaestroRequest request);
        Task<BaseResponse<MaestroResponse>> Registrar(MaestroRequest request);
        Task<BaseResponse<MaestroResponse>> BuscarPorId(int idMaestro);
        Task<BaseResponse> Actualizar(MaestroRequest request);
        Task<BaseResponse<MaestroDetalleResponse>> RegistrarDetalle(MaestroDetalleRequest request);
        Task<BaseResponse> ActualizarDetalle(MaestroDetalleRequest request);
        Task<BaseResponse<MaestroDetalleResponse>> BuscarDetallePorId(int IdMaestroDetalle);
        Task<BaseResponse<List<DetalleMaestroResponse>>> ListarDetalleMaestroByCodigo(ListaDetalleMaestroRequest request);
        Task<BaseResponse<List<DetalleMaestroResponse>>> ListarDetalleMaestroByListCodigos(List<string> listCodigos);
    }
}
