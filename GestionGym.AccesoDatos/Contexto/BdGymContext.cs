using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GestionGym.Entidades;
using System.Reflection;

namespace GestionGym.AccesoDatos.Contexto;

public partial class BdGymContext(DbContextOptions<BdGymContext> options) : DbContext(options)
{
    public virtual DbSet<Aplicacionejercicio> Aplicacionejercicios { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Colaborador> Colaboradors { get; set; }

    public virtual DbSet<Colaboradorusuario> Colaboradorusuarios { get; set; }

    public virtual DbSet<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; }

    public virtual DbSet<ControlavanceCliente> ControlavanceClientes { get; set; }

    public virtual DbSet<ControlfisicoCliente> ControlfisicoClientes { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Establecimiento> Establecimientos { get; set; }

    public virtual DbSet<Fichacliente> Fichaclientes { get; set; }

    public virtual DbSet<HistorialmedicoCliente> HistorialmedicoClientes { get; set; }

    public virtual DbSet<Informeinstructor> Informeinstructors { get; set; }

    public virtual DbSet<Ingresocaja> Ingresocajas { get; set; }

    public virtual DbSet<Maestro> Maestros { get; set; }

    public virtual DbSet<Maestrodetalle> Maestrodetalles { get; set; }

    public virtual DbSet<Maquina> Maquinas { get; set; }

    public virtual DbSet<Maquinaejercicio> Maquinaejercicios { get; set; }

    public virtual DbSet<Movimientocaja> Movimientocajas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Recursosejercicio> Recursosejercicios { get; set; }

    public virtual DbSet<Rutinacliente> Rutinaclientes { get; set; }

    public virtual DbSet<RutinaclienteDetalle> RutinaclienteDetalles { get; set; }

    public virtual DbSet<Rutinaejercicio> Rutinaejercicios { get; set; }

    public virtual DbSet<Salidacaja> Salidacajas { get; set; }

    public virtual DbSet<Suscripcion> Suscripcions { get; set; }

    public virtual DbSet<Suscripciondetalle> Suscripciondetalles { get; set; }

    public virtual DbSet<Maquinaestablecimiento> Maquinaestablecimientos { get; set; }

    public virtual DbSet<Preciossuscripcion> Preciossuscripcions { get; set; }

    public virtual DbSet<Recursosmaquina> Recursosmaquinas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
   
}
