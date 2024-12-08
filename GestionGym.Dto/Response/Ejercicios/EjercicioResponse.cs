using GestionGym.Dto.Request.Ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Ejercicios
{
    public class EjercicioResponse
    {
        public int Id { get; set; }

        public int IdGrupoMuscular { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int IdEstablecimiento { get; set; }
        public List<RutinaEjercicioRequest> Rutina { get; set; } = new();
        public List<RecursoEjercicioRequest> Recursos { get; set; } = new();
    }
}
