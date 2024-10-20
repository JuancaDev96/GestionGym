using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Maestro : EntidadBase
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
        public int? Idestablecimiento { get; set; }

        public virtual Establecimiento? IdestablecimientoNavigation { get; set; }
        public virtual ICollection<Maestrodetalle> Maestrodetalles { get; set; } = new List<Maestrodetalle>();
    }
}