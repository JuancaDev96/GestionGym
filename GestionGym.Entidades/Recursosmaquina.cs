using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Recursosmaquina : EntidadBase
    {
        public int Id { get; set; }

        public int Idmaquina { get; set; }

        public string? Ruta { get; set; }

        public string? Camporeservado { get; set; }

        public virtual Maquina IdmaquinaNavigation { get; set; } = null!;
    }
}