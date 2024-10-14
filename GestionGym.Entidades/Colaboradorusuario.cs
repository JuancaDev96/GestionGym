using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Colaboradorusuario : EntidadBase
    {
        public int Id { get; set; }

        public int Idcolaborador { get; set; }

        public string? Usuario { get; set; }

        public string? Clave { get; set; }

        public DateTime? Bloqueadohasta { get; set; }

        public DateTime? Ultimobloqueo { get; set; }

        public int? Intentosfallidos { get; set; }

        public virtual ICollection<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; } = new List<Colaboradorusuariopermiso>();

        public virtual Colaborador IdcolaboradorNavigation { get; set; } = null!;
    }
}