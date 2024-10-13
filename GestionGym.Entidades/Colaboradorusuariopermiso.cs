using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Colaboradorusuariopermiso : EntidadBase
{
    public int Id { get; set; }

    public int Idcolaboradorusuario { get; set; }

    public int Idpermiso { get; set; }

    public virtual Colaboradorusuario IdcolaboradorusuarioNavigation { get; set; } = null!;

    public virtual Permiso IdpermisoNavigation { get; set; } = null!;
}
