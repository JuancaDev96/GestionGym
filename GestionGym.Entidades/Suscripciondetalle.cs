using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Suscripciondetalle : EntidadBase
    {
        public int Id { get; set; }

        public int Idsuscripcion { get; set; }

        public int Idmovimientocaja { get; set; }

        public DateTime? Fechafijapagada { get; set; }

        public DateTime? Periodoiniciopagado { get; set; }

        public DateTime? Periodofinpagado { get; set; }

        public virtual Movimientocaja IdmovimientocajaNavigation { get; set; } = null!;

        public virtual Suscripcion IdsuscripcionNavigation { get; set; } = null!;
    }
}