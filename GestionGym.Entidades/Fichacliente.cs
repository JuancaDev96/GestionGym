using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Fichacliente : EntidadBase
    {
        public int Id { get; set; }

        public int Idcliente { get; set; }

        public DateTime? Fechainicio { get; set; }

        public string? Objetivo { get; set; }

        public int? Nivel { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;

        public virtual Maestrodetalle IdestadoactualParametroNavigation { get; set; } = null!;
    }
}