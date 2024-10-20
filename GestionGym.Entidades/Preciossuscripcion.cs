using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Preciossuscripcion
{
    public int Id { get; set; }

    public int IdtiposuscripcionParametro { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool Estado { get; set; }

    public DateTime Fecharegistro { get; set; }

    public string Usuarioregistro { get; set; } = null!;

    public DateTime? Fechamodificacion { get; set; }

    public string? Usuariomodificacion { get; set; }

    public virtual Maestrodetalle IdtiposuscripcionParametroNavigation { get; set; } = null!;
}
