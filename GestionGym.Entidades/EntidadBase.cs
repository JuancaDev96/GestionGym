using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades
{
    public class EntidadBase
    {
        public bool Estado { get; set; } = true;

        public DateTime Fecharegistro { get; set; } = DateTime.Now;

        public string Usuarioregistro { get; set; } = Environment.UserName;

        public DateTime? Fechamodificacion { get; set; }

        public string? Usuariomodificacion { get; set; }
    }
}
