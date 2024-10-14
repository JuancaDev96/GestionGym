using GestionGym.Entidades;
using System;
using System.Collections.Generic;

namespace GestionGym.Entidades
{

    public partial class Maestrodetalle : EntidadBase
    {
        public int Id { get; set; }

        public int Idmaestro { get; set; }

        public string Codigo { get; set; } = null!;

        public string Valor { get; set; } = null!;

        public string? Descripcion { get; set; }

        /// <summary>
        /// Define si el parametro se utilizaria sin necesidad de seleccionarlo
        /// </summary>
        public bool? Esdefault { get; set; }

        public bool? Esbool { get; set; }

        public virtual ICollection<Aplicacionejercicio> Aplicacionejercicios { get; set; } = new List<Aplicacionejercicio>();

        public virtual ICollection<ControlavanceCliente> ControlavanceClientes { get; set; } = new List<ControlavanceCliente>();

        public virtual ICollection<ControlfisicoCliente> ControlfisicoClientes { get; set; } = new List<ControlfisicoCliente>();

        public virtual ICollection<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();

        public virtual ICollection<Fichacliente> Fichaclientes { get; set; } = new List<Fichacliente>();

        public virtual ICollection<HistorialmedicoCliente> HistorialmedicoClientes { get; set; } = new List<HistorialmedicoCliente>();

        public virtual Maestro IdmaestroNavigation { get; set; } = null!;

        public virtual ICollection<Ingresocaja> Ingresocajas { get; set; } = new List<Ingresocaja>();

        public virtual ICollection<Maquina> MaquinaIdestadomaquinaParametroNavigations { get; set; } = new List<Maquina>();

        public virtual ICollection<Maquina> MaquinaIdgrupomuscularParametroNavigations { get; set; } = new List<Maquina>();

        public virtual ICollection<RutinaclienteDetalle> RutinaclienteDetalles { get; set; } = new List<RutinaclienteDetalle>();

        public virtual ICollection<Salidacaja> Salidacajas { get; set; } = new List<Salidacaja>();

        public virtual ICollection<Suscripcion> SuscripcionIdestadosuscripcionParametroNavigations { get; set; } = new List<Suscripcion>();

        public virtual ICollection<Suscripcion> SuscripcionIdtiposuscripcionParametroNavigations { get; set; } = new List<Suscripcion>();
    }
}