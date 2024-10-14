using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Salidacaja : EntidadBase
    {
        public int Id { get; set; }

        public int Idmovimiento { get; set; }

        public int IdmedioParametro { get; set; }

        public decimal Monto { get; set; }

        public virtual Maestrodetalle IdmedioParametroNavigation { get; set; } = null!;

        public virtual Movimientocaja IdmovimientoNavigation { get; set; } = null!;
    }
}