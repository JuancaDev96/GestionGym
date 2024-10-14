using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Ingresocaja : EntidadBase
    {
        public int Id { get; set; }

        public int Idmovimiento { get; set; }

        public int Idcliente { get; set; }

        public int IdmedioParametro { get; set; }

        public decimal Monto { get; set; }

        public decimal? Pagocon { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;

        public virtual Maestrodetalle IdmedioParametroNavigation { get; set; } = null!;

        public virtual Movimientocaja IdmovimientoNavigation { get; set; } = null!;
    }
}