using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Interfaces
{
    public interface IClienteService
    {
        Task<PaginationResponse<ListaClientesResponse>> ListarClientes(BusquedaClientesRequest request);
        Task<BaseResponse<int>> GuardarDatosPersonales(DatosPersonalesRequest request);
    }
}
