using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades.Response.Clientes
{
    public class ClientePaginadoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string? Dni { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; } = default!;
        public string? Suscripcion { get; set; } 
        public string? TipoSuscripcion { get; set; }
        public string? EstadoSuscripcion { get; set; }
        public int totalRegistros { get; set; } = 0;
    }
}
