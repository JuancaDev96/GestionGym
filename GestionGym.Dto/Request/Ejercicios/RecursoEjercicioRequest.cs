using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Ejercicios
{
    public class RecursoEjercicioRequest
    {
        public int IdEjercicio { get; set; }
        public string Recurso { get; set; } = default!;
        public string NombreRecurso { get; set; } = default!;
        public int IdTipoRecurso { get; set; }
    }
}
