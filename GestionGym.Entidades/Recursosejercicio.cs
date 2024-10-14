using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Recursosejercicio : EntidadBase
    {
        public int Id { get; set; }

        public int Idejercicio { get; set; }

        public string Ruta { get; set; } = null!;

        public virtual Ejercicio IdejercicioNavigation { get; set; } = null!;
    }
}