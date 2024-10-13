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
    }
}
