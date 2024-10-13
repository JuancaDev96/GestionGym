using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Puesto : EntidadBase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Colaborador> Colaboradors { get; set; } = new List<Colaborador>();
}
