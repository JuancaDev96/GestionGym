using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Permiso : EntidadBase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; } = new List<Colaboradorusuariopermiso>();
}
