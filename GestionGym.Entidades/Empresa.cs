using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Empresa : EntidadBase
    {
        public int Id { get; set; }

        public string? Razonsocial { get; set; }

        public string? Nombrecomercial { get; set; }

        public string? Direccionfiscal { get; set; }

        public string? Ubigeo { get; set; }

        public string Ruc { get; set; } = null!;

        public string Celular { get; set; } = null!;

        public string Representante { get; set; } = null!;

        public string Contacto { get; set; } = null!;

        public string? Urlfacebook { get; set; }

        public string? Urlinstagram { get; set; }

        public string? Urltiktok { get; set; }

        public string? Urladicional { get; set; }

        public string? Rutalogo { get; set; }

        public string? Rutavideo { get; set; }

        public virtual ICollection<Establecimiento> Establecimientos { get; set; } = new List<Establecimiento>();
    }
}