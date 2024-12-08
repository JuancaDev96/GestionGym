using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Ejercicio : EntidadBase
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? IdEstablecimiento { get; set; }

        public virtual ICollection<Aplicacionejercicio> Aplicacionejercicios { get; set; } = new List<Aplicacionejercicio>();

        public virtual ICollection<Ejerciciogrupomuscular> Ejerciciogrupomusculars { get; set; } = new List<Ejerciciogrupomuscular>();

        public virtual Establecimiento? IdestablecimientoNavigation { get; set; }

        public virtual ICollection<Maquinaejercicio> Maquinaejercicios { get; set; } = new List<Maquinaejercicio>();

        public virtual ICollection<Recursosejercicio> Recursosejercicios { get; set; } = new List<Recursosejercicio>();

        public virtual ICollection<Rutinaejercicio> Rutinaejercicios { get; set; } = new List<Rutinaejercicio>();
    }
}