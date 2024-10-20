using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Maestros
{
    public class MaestroRequest
    {
        public int IdEstablecimiento { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; } = null!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
    }
}
