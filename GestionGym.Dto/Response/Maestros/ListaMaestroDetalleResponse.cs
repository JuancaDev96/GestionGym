using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Maestros
{
    public class ListaMaestroDetalleResponse
    {
        public int IdDetalleMaestro { get; set; }
        [Display(Name = "Código")]
        public string Codigo { get; set; } = default!;
        [Display(Name = "Parametro")]
        public string Valor { get; set; } = default!;
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Es Default")]
        public bool EsDefault { get; set; }
        [Display(Name = "Es Bool")]
        public bool EsBool { get; set; }
    }
}
