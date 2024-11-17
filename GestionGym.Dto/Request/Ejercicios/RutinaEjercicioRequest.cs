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
        public int Idejercicio { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Repeticiones { get; set; }
        public int Series { get; set; }
    }
}
