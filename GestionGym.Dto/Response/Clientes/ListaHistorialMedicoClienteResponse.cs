using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Clientes
{
    public class ListaHistorialMedicoClienteResponse
    {
        public int Id { get; set; }

        public int IdHistorial { get; set; }

        public string NombreHistorial { get; set; } = default!;

        public int IdCliente { get; set; }

        public string? Valor { get; set; }

        public string? Recomendacion { get; set; }

        public string? Consideracion { get; set; }

        public string? Comentario { get; set; }
    }
}
