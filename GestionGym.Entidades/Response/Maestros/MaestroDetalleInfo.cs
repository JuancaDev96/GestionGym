using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades.Response.Maestros
{
    public class MaestroDetalleInfo
    {
        public int IdDetalleMaestro { get; set; }
        public string Codigo { get; set; } = default!;
        public string Valor { get; set; } = default!;
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsDefault { get; set; }
        public bool EsBool { get; set; }
    }
}
