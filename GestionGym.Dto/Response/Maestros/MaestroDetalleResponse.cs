using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Maestros
{
    public class MaestroDetalleResponse
    {
        public int Id { get; set; }

        public int Idmaestro { get; set; }

        public string Codigo { get; set; } = null!;

        public string Valor { get; set; } = null!;

        public string? Descripcion { get; set; }

        public bool? Esdefault { get; set; }

        public bool? Esbool { get; set; }
    }
}
