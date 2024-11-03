using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Ejercicios
{
    public class RutinaEjercicioRequest
    {
        public int Orden { get; set; }
        public int Id { get; set; }
        public int IdEjercicio { get; set; }
        public string? Comentario { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
    }
}
