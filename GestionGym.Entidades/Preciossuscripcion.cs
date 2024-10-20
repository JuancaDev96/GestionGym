using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Preciossuscripcion : EntidadBase
{
    public int Id { get; set; }

    public int IdtiposuscripcionParametro { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual Maestrodetalle IdtiposuscripcionParametroNavigation { get; set; } = null!;
}
