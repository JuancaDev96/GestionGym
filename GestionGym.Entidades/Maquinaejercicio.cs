using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Maquinaejercicio : EntidadBase
{
    public int Id { get; set; }

    public int Idmaquina { get; set; }

    public int Idejercicio { get; set; }

    public bool? Esmaquina { get; set; }

    public virtual Ejercicio IdejercicioNavigation { get; set; } = null!;

    public virtual Maquina IdmaquinaNavigation { get; set; } = null!;
}
