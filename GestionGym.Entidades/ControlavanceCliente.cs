using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class ControlavanceCliente : EntidadBase
{
    public int Id { get; set; }

    public int Idparametro { get; set; }

    public int Idcliente { get; set; }

    public string? Valor { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual Maestrodetalle IdparametroNavigation { get; set; } = null!;
}
