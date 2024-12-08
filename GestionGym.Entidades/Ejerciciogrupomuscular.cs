using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Ejerciciogrupomuscular : EntidadBase
{
    public int Id { get; set; }

    public int Idejercicio { get; set; }

    public int IdgrupomuscularParametro { get; set; }

    public virtual Ejercicio IdejercicioNavigation { get; set; } = null!;

    public virtual Maestrodetalle IdgrupomuscularParametroNavigation { get; set; } = null!;
}
