using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Caja : EntidadBase
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Movimientocaja> Movimientocajas { get; set; } = new List<Movimientocaja>();
}
