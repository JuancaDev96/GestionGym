using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Ejercicios
{
    public class ListaEjerciciosResponse
    {
        public int Id { get; set; }

        [Display]
        public string Nombre { get; set; } = default!;

        [Display]
        public string Descripcion { get; set; } = default!;

        [Display(Name = "Grupo muscular")]
        public string GrupoMuscular { get; set; } = default!;

        public DateTime FechaRegistro { get; set; }
    }
}
