using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Maquinagrupomuscular : EntidadBase
{
    public int Id { get; set; }

    public int Idmaquina { get; set; }

    public int IdgrupomuscularParametro { get; set; }

    public virtual Maestrodetalle IdgrupomuscularParametroNavigation { get; set; } = null!;

    public virtual Maquina IdmaquinaNavigation { get; set; } = null!;
}
