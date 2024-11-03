using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Clientes
{
    public class HistorialMedicoClienteRequest
    {
        public int Id { get; set; }

        public string? Valor { get; set; }

        public string? Recomendacion { get; set; }

        public string? Consideracion { get; set; }

        public string? Comentario { get; set; }
    }
}
