using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Maestros
{
    public class BusquedaMaestroRequest : PaginationRequest
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
    }
}
