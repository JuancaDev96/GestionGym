using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Ejercicios
{
    public class BusquedaEjerciciosRequest : PaginationRequest  
    {
        public int? IdGrupoMuscular { get; set; }
        public string? Nombre { get; set; }
    }
}
