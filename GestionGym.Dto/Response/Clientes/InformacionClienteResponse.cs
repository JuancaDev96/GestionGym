using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Clientes
{
    public class InformacionClienteResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Dni { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        public DateOnly Fechanacimiento { get; set; }

        public int? Idestablecimiento { get; set; }
        public int Edad => Utils.CalcularEdadExacta(Fechanacimiento);
    }
}
