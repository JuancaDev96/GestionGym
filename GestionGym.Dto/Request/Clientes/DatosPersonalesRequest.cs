using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Clientes
{
    public class DatosPersonalesRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; } 

        public string? Dni { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        public DateTime Fechanacimiento { get; set; }
    }
}
