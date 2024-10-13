using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Aplicacionejercicio : EntidadBase
{
    public int Id { get; set; }

    public int Idejercicio { get; set; }

    public int IdaplicacionParametro { get; set; }

    public virtual Maestrodetalle IdaplicacionParametroNavigation { get; set; } = null!;

    public virtual Ejercicio IdejercicioNavigation { get; set; } = null!;
}
