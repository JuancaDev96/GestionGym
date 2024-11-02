using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades.Response.Clientes
{
    public class ClienteInfo
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Dni { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        public DateOnly Fechanacimiento { get; set; }

        public string Genero { get; set; }
        public int? Idgenero { get; set; }
    }

    public class FichaClienteInfo
    {
        public DateTime? FechaInicio { get; set; }
        public string Objetivo { get; set; } = default!;
        public string Nivel { get; set; } = default!;
    }
}
