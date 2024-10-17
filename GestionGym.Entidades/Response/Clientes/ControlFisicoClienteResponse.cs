using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades.Response.Clientes
{
    public class ControlFisicoClienteResponse
    {
        public int IdControlFisico { get; set; }
        public int IdParametro { get; set; }
        public int IdCliente { get; set; }
        public string NombreControl { get; set; } = default!;
        public string? DescripcionControl { get; set; }
        public string? ValorControl { get; set; }
    }
}
