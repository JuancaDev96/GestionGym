using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{
    public partial class Colaborador : EntidadBase
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Correoelectronico { get; set; }

        public int Idpuesto { get; set; }

        public int? Idestablecimiento { get; set; }

        public virtual ICollection<Colaboradorusuario> Colaboradorusuarios { get; set; } = new List<Colaboradorusuario>();

        public virtual Establecimiento? IdestablecimientoNavigation { get; set; }

        public virtual Puesto IdpuestoNavigation { get; set; } = null!;

        public virtual ICollection<Informeinstructor> Informeinstructors { get; set; } = new List<Informeinstructor>();
    }
}


