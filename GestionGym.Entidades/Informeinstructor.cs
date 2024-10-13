using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Informeinstructor : EntidadBase
{
    public int Id { get; set; }

    public int Idinstructor { get; set; }

    public int Idcliente { get; set; }

    public string? Consideracion { get; set; }

    public string? Comentario { get; set; }

    public int? Nivel { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual Colaborador IdinstructorNavigation { get; set; } = null!;
}
