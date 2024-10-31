using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Suscripciones
{
    public class SuscripcionRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string Nombre { get; set; } = default!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string Apellidos { get; set; } = default!;

        public string? Dni { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }

        [DeniedValues(0, ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Tipo de la suscripción")]
        public int IdTipoSuscripcion { get; set; }

        [DeniedValues(0, ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Precio de la suscripción")]
        public int IdPrecioSuscripcion { get; set; }

        [DeniedValues(0, ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Género")]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = default!;

        [DeniedValues(0, ErrorMessage = Constantes.requiredMessage)]
        public int IdObjetivo { get; set; } = default!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        [DeniedValues(0, ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Nivel")]
        public int IdNivel { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Fecha de nacimiento")]
        public DateOnly Fechanacimiento { get; set; } = new DateOnly(2000,01,01);
    }
}
