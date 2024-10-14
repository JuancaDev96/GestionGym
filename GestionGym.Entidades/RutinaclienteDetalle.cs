using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class RutinaclienteDetalle : EntidadBase
    {
        public int Id { get; set; }

        public int Idrutina { get; set; }

        public int Idejercicio { get; set; }

        public int Repeticiones { get; set; }

        public int IdtiporutinaParametro { get; set; }

        public int Series { get; set; }

        public int Descansominutos { get; set; }

        public string? Comentario { get; set; }

        public virtual Rutinacliente IdrutinaNavigation { get; set; } = null!;

        public virtual Maestrodetalle IdtiporutinaParametroNavigation { get; set; } = null!;
    }
}