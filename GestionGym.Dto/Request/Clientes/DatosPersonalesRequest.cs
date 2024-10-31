using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Request.Clientes
{
    public class DatosPersonalesRequest
    {
        public int Id { get; set; }
        public int IdEstablecimiento { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string Nombre { get; set; } = default!;

        [Required(ErrorMessage = Constantes.requiredMessage)]
        public string Apellidos { get; set; } = default!;

        [MinLength(8, ErrorMessage = Constantes.minLength)]
        public string? Dni { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        [Required(ErrorMessage = Constantes.requiredMessage)]
        [Display(Name = "Fecha de nacimiento")]
        public DateOnly Fechanacimiento { get; set; }
        public int Edad { get; set; }
    }
}
