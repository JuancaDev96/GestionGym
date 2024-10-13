using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Rutinacliente : EntidadBase
{
    public int Id { get; set; }

    public int Idcliente { get; set; }

    public int Dia { get; set; }

    public string? Comentario { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual ICollection<RutinaclienteDetalle> RutinaclienteDetalles { get; set; } = new List<RutinaclienteDetalle>();
}
