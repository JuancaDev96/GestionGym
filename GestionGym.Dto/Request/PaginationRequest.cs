using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request
{
    public class PaginationRequest
    {
        public int Pagina { get; set; }
        public int Filas { get; set; }
    }
}
