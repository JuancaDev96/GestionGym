using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Suscripcion : EntidadBase
    {
        public int Id { get; set; }

        public int Idcliente { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdtiposuscripcionParametro { get; set; }

        public int IdestadosuscripcionParametro { get; set; }

        public int? Idpreciosuscripcion { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;

        public virtual Maestrodetalle IdestadosuscripcionParametroNavigation { get; set; } = null!;

        public virtual Preciossuscripcion? IdpreciosuscripcionNavigation { get; set; }

        public virtual Maestrodetalle IdtiposuscripcionParametroNavigation { get; set; } = null!;

        public virtual ICollection<Suscripciondetalle> Suscripciondetalles { get; set; } = new List<Suscripciondetalle>();
    }
}