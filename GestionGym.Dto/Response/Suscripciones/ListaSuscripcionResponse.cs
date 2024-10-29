using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Suscripciones
{
    public class ListaSuscripcionResponse
    {
        public int IdSuscripcion { get; set; }
        public int IdCliente { get; set; }
        [Display]
        public string Cliente { get; set; } = default!;
        [Display(Name = "Dni")]
        public string DniCliente { get; set; } = default!;
        [Display(Name = "Tipo suscripción")]
        public string TipoSuscripcion { get; set; } = default!;
        [Display(Name = "Estado")]
        public string EstadoSuscripcion { get; set; } = default!;
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
