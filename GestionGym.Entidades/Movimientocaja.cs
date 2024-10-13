using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Movimientocaja : EntidadBase
{
    public int Id { get; set; }

    public int Idcaja { get; set; }

    public int Idcliente { get; set; }

    public bool Esingreso { get; set; }

    public string Concepto { get; set; } = null!;
    public int IdmedioParametro { get; set; }

    public decimal Monto { get; set; }

    public decimal? Pagocon { get; set; }

    public virtual Caja IdcajaNavigation { get; set; } = null!;

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual ICollection<Suscripciondetalle> Suscripciondetalles { get; set; } = new List<Suscripciondetalle>();
    public virtual Maestrodetalle IdmedioParametroNavigation { get; set; } = null!;
}
