using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Maestros
{
    public class DetalleMaestroResponse
    {
        public int IdDetalleMaestro { get; set; }
        public string CodigoPadre { get; set; } = default!;
        public string Codigo { get; set; } = default!;
        [Display(Name = "Parametro")]
        public string Valor { get; set; } = default!;
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsExistente { get; set; } = false;
    }
}
