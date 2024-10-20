using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Maestros
{
    public class ListaMaestrosResponse
    {
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; } = null!;

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
    }
}
