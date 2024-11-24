using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Ejercicios
{
    public class RutinaEjercicioResponse
    {
        public int Id { get; set; }
        public int Idejercicio { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Repeticiones { get; set; }
        public int Series { get; set; }
    }
}
