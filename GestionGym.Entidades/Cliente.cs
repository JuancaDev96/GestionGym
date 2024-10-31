using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{
    public partial class Cliente : EntidadBase
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Dni { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        public DateOnly Fechanacimiento { get; set; }

        public int? Idestablecimiento { get; set; }
        public int? IdgeneroParametro { get; set; }

        public virtual ICollection<ControlavanceCliente> ControlavanceClientes { get; set; } = new List<ControlavanceCliente>();

        public virtual ICollection<ControlfisicoCliente> ControlfisicoClientes { get; set; } = new List<ControlfisicoCliente>();

        public virtual ICollection<Fichacliente> Fichaclientes { get; set; } = new List<Fichacliente>();

        public virtual ICollection<HistorialmedicoCliente> HistorialmedicoClientes { get; set; } = new List<HistorialmedicoCliente>();

        public virtual Establecimiento? IdestablecimientoNavigation { get; set; }

        public virtual ICollection<Informeinstructor> Informeinstructors { get; set; } = new List<Informeinstructor>();

        public virtual ICollection<Ingresocaja> Ingresocajas { get; set; } = new List<Ingresocaja>();

        public virtual ICollection<Rutinacliente> Rutinaclientes { get; set; } = new List<Rutinacliente>();

        public virtual ICollection<Suscripcion> Suscripcions { get; set; } = new List<Suscripcion>();
        public virtual Maestrodetalle? IdgeneroParametroNavigation { get; set; }
    }

}
