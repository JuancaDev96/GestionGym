using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Suscripciones
{
    public class SuscripcionRequest
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string? Dni { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public int IdTipoSuscripcion { get; set; }
        public string Descripcion { get; set; } = default!;

        public string Objetivo { get; set; } = default!;
        public DateTime FechaInicio { get; set; }
        public int Nivel { get; set; }
    }
}
