using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Maquinaestablecimiento : EntidadBase
    {
        public int Id { get; set; }

        public int Idmaquina { get; set; }

        public int Idestablecimiento { get; set; }

        public virtual Establecimiento IdestablecimientoNavigation { get; set; } = null!;

        public virtual Maquina IdmaquinaNavigation { get; set; } = null!;
    }
}