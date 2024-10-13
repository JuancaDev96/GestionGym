using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Rutinaejercicio : EntidadBase
{
    public int Id { get; set; }

    public int Idejercicio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Repeticiones { get; set; }

    public int Series { get; set; }

    public virtual Ejercicio IdejercicioNavigation { get; set; } = null!;
}
