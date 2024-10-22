using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Maestros
{
    public class MaestroDetalleRequest
    {
        public int Id { get; set; }

        public int Idmaestro { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string Codigo { get; set; } = null!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string Valor { get; set; } = null!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        public bool? Esdefault { get; set; }

        public bool? Esbool { get; set; }
    }
}
