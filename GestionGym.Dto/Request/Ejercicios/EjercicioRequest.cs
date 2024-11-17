using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Ejercicios
{
    public class EjercicioRequest
    {
        public int Id { get; set; }

        [DeniedValues(0, ErrorMessage = "Seleccione el grupo muscular.")]
        public int IdGrupoMuscular { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string? Descripcion { get; set; }

        public int IdEstablecimiento { get; set; }

        public List<RutinaEjercicioRequest> Rutina { get; set; } = new();
    }
}
