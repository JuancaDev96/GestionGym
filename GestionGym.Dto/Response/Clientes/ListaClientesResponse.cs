﻿using GestionGym.Comun;
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
        public string Nombre { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        [Display(Name = "Nombre completo")]
        public string Cliente => $"{Nombre} {Apellidos}";
        [Display(Name = "Dni")]
        public string? Dni { get; set; }
        [Display(Name = "Celular")]
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Display(Name = "Edad")]
        public int Edad => Utils.CalcularEdadExacta(Convert.ToDateTime(FechaNacimiento));
        public DateTime FechaRegistro { get; set; } = default!;
        [Display(Name = "Suscripción")]
        public string? Suscripcion { get; set; }
        public string? TipoSuscripcion { get; set; }
        public string? EstadoSuscripcion { get; set; }
        [Display(Name = "Hoy")]
        public string? EstadoDia { get; set; }
        public int totalRegistros { get; set; } = 0;
    }
}