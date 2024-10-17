using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Clientes
{
    public class ListaControlFisicoClienteResponse
    {
        public int IdControlFisico { get; set; }
        public int IdParametro { get; set; }
        public int IdCliente { get; set; }
        public string NombreControl { get; set; } = default!;
        public string? DescripcionControl { get; set; }
        public string? ValorControl { get; set; }
    }
}
