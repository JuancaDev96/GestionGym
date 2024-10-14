using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Maquina : EntidadBase
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int IdgrupomuscularParametro { get; set; }

        public string? Ubicacion { get; set; }

        public int IdestadomaquinaParametro { get; set; }

        public bool? Requieresupervision { get; set; }

        public virtual Maestrodetalle IdestadomaquinaParametroNavigation { get; set; } = null!;

        public virtual Maestrodetalle IdgrupomuscularParametroNavigation { get; set; } = null!;

        public virtual ICollection<Maquinaejercicio> Maquinaejercicios { get; set; } = new List<Maquinaejercicio>();
        public virtual ICollection<Maquinaestablecimiento> Maquinaestablecimientos { get; set; } = new List<Maquinaestablecimiento>();
        public virtual ICollection<Recursosmaquina> Recursosmaquinas { get; set; } = new List<Recursosmaquina>();
    }
}