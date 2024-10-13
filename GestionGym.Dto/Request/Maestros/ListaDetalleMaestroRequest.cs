using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Maestros
{
    public class ListaDetalleMaestroRequest : PaginationRequest
    {
        public string codigoMaestro { get; set; } = default!;
    }
}
