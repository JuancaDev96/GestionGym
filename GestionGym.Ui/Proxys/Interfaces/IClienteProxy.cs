using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Response;
using GestionGym.Dto.Request.Clientes;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface IClienteProxy
    {
        Task<PaginationResponse<ListaClientesResponse>> GetClientes(BusquedaClientesRequest request);
        Task<BaseResponse<List<ListaControlFisicoClienteResponse>>> GetControlFisicoParametros(int idCliente);
        Task<BaseResponse<int>> GuardarDatosPersonales(DatosPersonalesRequest request);
    }
}
