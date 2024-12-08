using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades.Response.Ejercicios
{
    public class RecursosEjercicioInfo
    {
        public int Id { get; set; }
        public int Idejercicio { get; set; }
        public string Ruta { get; set; } = null!;
        public int? IdTipoRecurso { get; set; }
        public string CodigoTipoRecurso { get; set; } = null!;
        public string TipoRecurso { get; set; } = null!;
    }
}
