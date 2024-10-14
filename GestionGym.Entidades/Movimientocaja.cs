using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Movimientocaja : EntidadBase
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public string Correlativo { get; set; } = null!;

        public int Idcaja { get; set; }

        public bool Esingreso { get; set; }

        public string Concepto { get; set; } = null!;

        public decimal Monto { get; set; }

        public virtual Caja IdcajaNavigation { get; set; } = null!;
        public virtual ICollection<Ingresocaja> Ingresocajas { get; set; } = new List<Ingresocaja>();

        public virtual ICollection<Salidacaja> Salidacajas { get; set; } = new List<Salidacaja>();

        public virtual ICollection<Suscripciondetalle> Suscripciondetalles { get; set; } = new List<Suscripciondetalle>();
    }
}