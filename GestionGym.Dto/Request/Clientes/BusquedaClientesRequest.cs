using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Clientes
{
    public class BusquedaClientesRequest : PaginationRequest
    {
        public string? Nombre { get; set; } = string.Empty;
        public string? Dni { get; set; } = string.Empty;

    }
}
