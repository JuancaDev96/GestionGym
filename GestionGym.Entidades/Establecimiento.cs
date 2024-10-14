using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Establecimiento : EntidadBase
    {
        public int Id { get; set; }

        public int Idempresa { get; set; }

        public string? Nombrecomercial { get; set; }

        public string? Direccion { get; set; }

        public string? Ubigeo { get; set; }

        public string Celular { get; set; } = null!;

        public string Contacto { get; set; } = null!;

        public string? Urladicional { get; set; }

        public string? Rutalogo { get; set; }

        public string? Rutavideo { get; set; }

        public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

        public virtual ICollection<Colaborador> Colaboradors { get; set; } = new List<Colaborador>();

        public virtual Empresa IdempresaNavigation { get; set; } = null!;
        public virtual ICollection<Maquinaestablecimiento> Maquinaestablecimientos { get; set; } = new List<Maquinaestablecimiento>();
    }
}