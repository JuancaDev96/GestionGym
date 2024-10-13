using System;
using System.Collections.Generic;

namespace GestionGym.Entidades;

public partial class Ejercicio : EntidadBase
{
    public int Id { get; set; }

    public int IdgrupomuscularParametro { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Aplicacionejercicio> Aplicacionejercicios { get; set; } = new List<Aplicacionejercicio>();

    public virtual Maestrodetalle IdgrupomuscularParametroNavigation { get; set; } = null!;

    public virtual ICollection<Maquinaejercicio> Maquinaejercicios { get; set; } = new List<Maquinaejercicio>();

    public virtual ICollection<Recursosejercicio> Recursosejercicios { get; set; } = new List<Recursosejercicio>();

    public virtual ICollection<Rutinaejercicio> Rutinaejercicios { get; set; } = new List<Rutinaejercicio>();
}
