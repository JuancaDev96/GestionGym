using GestionGym.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Clientes
{
    public class ListaClientesResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        [Display(Name = "Nombre completo")]
        public string Cliente => $"{Nombre} {Apellidos}";
        [Display(Name = "Dni")]
        public string? Dni { get; set; }
        [Display(Name = "Celular")]
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Edad")]
        public int Edad => Utils.CalcularEdadExacta(DateOnly.FromDateTime(FechaNacimiento));
        public DateTime FechaRegistro { get; set; } = default!;
       
        public string? Suscripcion { get; set; }

        [Display(Name = "Suscripción")]
        public string? TipoSuscripcion { get; set; }
        public string? EstadoSuscripcion { get; set; }
        public string? EstadoDia { get; set; }
    }
}
