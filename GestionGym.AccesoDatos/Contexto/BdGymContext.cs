using System;
using System.Collections.Generic;
using GestionGym.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.AccesoDatos.Contexto;

public partial class BdGymContext : DbContext
{
    public BdGymContext()
    {
    }

    public BdGymContext(DbContextOptions<BdGymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aplicacionejercicio> Aplicacionejercicios { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Colaborador> Colaboradors { get; set; }

    public virtual DbSet<Colaboradorusuario> Colaboradorusuarios { get; set; }

    public virtual DbSet<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; }

    public virtual DbSet<ControlavanceCliente> ControlavanceClientes { get; set; }

    public virtual DbSet<ControlfisicoCliente> ControlfisicoClientes { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Fichacliente> Fichaclientes { get; set; }

    public virtual DbSet<HistorialmedicoCliente> HistorialmedicoClientes { get; set; }

    public virtual DbSet<Informeinstructor> Informeinstructors { get; set; }

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

    public virtual DbSet<Suscripcion> Suscripcions { get; set; }

    public virtual DbSet<Suscripciondetalle> Suscripciondetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aplicacionejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aplicacionejercicio_pkey");

            entity.ToTable("aplicacionejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.IdaplicacionParametro).HasColumnName("idaplicacion_parametro");
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdaplicacionParametroNavigation).WithMany(p => p.Aplicacionejercicios)
                .HasForeignKey(d => d.IdaplicacionParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aplicacionejercicio_aplicacion");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Aplicacionejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aplicacionejercicio_ejercicio");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("caja_pkey");

            entity.ToTable("caja");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Celular)
                .HasMaxLength(9)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(12)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fechanacimiento).HasColumnName("fechanacimiento");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");
        });

        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaborador_pkey");

            entity.ToTable("colaborador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correoelectronico)
                .HasMaxLength(100)
                .HasColumnName("correoelectronico");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdpuestoNavigation).WithMany(p => p.Colaboradors)
                .HasForeignKey(d => d.Idpuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaborador_puesto");
        });

        modelBuilder.Entity<Colaboradorusuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaboradorusuario_pkey");

            entity.ToTable("colaboradorusuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bloqueadohasta)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("bloqueadohasta");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcolaborador).HasColumnName("idcolaborador");
            entity.Property(e => e.Intentosfallidos).HasColumnName("intentosfallidos");
            entity.Property(e => e.Ultimobloqueo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimobloqueo");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdcolaboradorNavigation).WithMany(p => p.Colaboradorusuarios)
                .HasForeignKey(d => d.Idcolaborador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuario_colaborador");
        });

        modelBuilder.Entity<Colaboradorusuariopermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colaboradorusuariopermiso_pkey");

            entity.ToTable("colaboradorusuariopermiso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcolaboradorusuario).HasColumnName("idcolaboradorusuario");
            entity.Property(e => e.Idpermiso).HasColumnName("idpermiso");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdcolaboradorusuarioNavigation).WithMany(p => p.Colaboradorusuariopermisos)
                .HasForeignKey(d => d.Idcolaboradorusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuariopermiso_colaboradorusuario");

            entity.HasOne(d => d.IdpermisoNavigation).WithMany(p => p.Colaboradorusuariopermisos)
                .HasForeignKey(d => d.Idpermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuariopermiso_permiso");
        });

        modelBuilder.Entity<ControlavanceCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("controlavance_cliente_pkey");

            entity.ToTable("controlavance_cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idparametro).HasColumnName("idparametro");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");
            entity.Property(e => e.Valor)
                .HasMaxLength(30)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.ControlavanceClientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controlavance_cliente_cliente");

            entity.HasOne(d => d.IdparametroNavigation).WithMany(p => p.ControlavanceClientes)
                .HasForeignKey(d => d.Idparametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controlavance_cliente_maestrodetalle");
        });

        modelBuilder.Entity<ControlfisicoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("controlfisico_cliente_pkey");

            entity.ToTable("controlfisico_cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idparametro).HasColumnName("idparametro");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");
            entity.Property(e => e.Valor)
                .HasMaxLength(30)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.ControlfisicoClientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controlfisico_cliente_cliente");

            entity.HasOne(d => d.IdparametroNavigation).WithMany(p => p.ControlfisicoClientes)
                .HasForeignKey(d => d.Idparametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controlfisico_cliente_maestrodetalle");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ejercicio_pkey");

            entity.ToTable("ejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.IdgrupomuscularParametro).HasColumnName("idgrupomuscular_parametro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdgrupomuscularParametroNavigation).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.IdgrupomuscularParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aplicacionejercicio_grupomuscular");
        });

        modelBuilder.Entity<Fichacliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fichacliente_pkey");

            entity.ToTable("fichacliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechainicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.IdestadoactualParametro).HasColumnName("idestadoactual_parametro");
            entity.Property(e => e.Nivel).HasColumnName("nivel");
            entity.Property(e => e.Objetivo)
                .HasMaxLength(150)
                .HasColumnName("objetivo");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Fichaclientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fichacliente_cliente");

            entity.HasOne(d => d.IdestadoactualParametroNavigation).WithMany(p => p.Fichaclientes)
                .HasForeignKey(d => d.IdestadoactualParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aplicacionejercicio_estadoactual");
        });

        modelBuilder.Entity<HistorialmedicoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("historialmedico_cliente_pkey");

            entity.ToTable("historialmedico_cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(100)
                .HasColumnName("comentario");
            entity.Property(e => e.Consideracion)
                .HasMaxLength(100)
                .HasColumnName("consideracion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idparametro).HasColumnName("idparametro");
            entity.Property(e => e.Recomendacion)
                .HasMaxLength(100)
                .HasColumnName("recomendacion");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");
            entity.Property(e => e.Valor)
                .HasMaxLength(30)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.HistorialmedicoClientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialmedico_cliente_cliente");

            entity.HasOne(d => d.IdparametroNavigation).WithMany(p => p.HistorialmedicoClientes)
                .HasForeignKey(d => d.Idparametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialmedico_cliente_maestrodetalle");
        });

        modelBuilder.Entity<Informeinstructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("informeinstructor_pkey");

            entity.ToTable("informeinstructor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(300)
                .HasColumnName("comentario");
            entity.Property(e => e.Consideracion)
                .HasMaxLength(300)
                .HasColumnName("consideracion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idinstructor).HasColumnName("idinstructor");
            entity.Property(e => e.Nivel).HasColumnName("nivel");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Informeinstructors)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_informeinstructor_cliente");

            entity.HasOne(d => d.IdinstructorNavigation).WithMany(p => p.Informeinstructors)
                .HasForeignKey(d => d.Idinstructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_informeinstructor_instructor");
        });

        modelBuilder.Entity<Maestro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("maestro_pkey");

            entity.ToTable("maestro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");
        });

        modelBuilder.Entity<Maestrodetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("maestrodetalle_pkey");

            entity.ToTable("maestrodetalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idmaestro).HasColumnName("idmaestro");
            entity.Property(e => e.Usuariomodificacion).HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro).HasColumnName("usuarioregistro");
            entity.Property(e => e.Valor)
                .HasMaxLength(150)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdmaestroNavigation).WithMany(p => p.Maestrodetalles)
                .HasForeignKey(d => d.Idmaestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maestrodetalle_maestro");
        });

        modelBuilder.Entity<Maquina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("maquina_pkey");

            entity.ToTable("maquina");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.IdestadomaquinaParametro).HasColumnName("idestadomaquina_parametro");
            entity.Property(e => e.IdgrupomuscularParametro).HasColumnName("idgrupomuscular_parametro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Requieresupervision).HasColumnName("requieresupervision");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .HasColumnName("ubicacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdestadomaquinaParametroNavigation).WithMany(p => p.MaquinaIdestadomaquinaParametroNavigations)
                .HasForeignKey(d => d.IdestadomaquinaParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquina_estadomaquina");

            entity.HasOne(d => d.IdgrupomuscularParametroNavigation).WithMany(p => p.MaquinaIdgrupomuscularParametroNavigations)
                .HasForeignKey(d => d.IdgrupomuscularParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquina_grupomuscular");
        });

        modelBuilder.Entity<Maquinaejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("maquinaejercicio_pkey");

            entity.ToTable("maquinaejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Esmaquina).HasColumnName("esmaquina");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Idmaquina).HasColumnName("idmaquina");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Maquinaejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinaejercicio_ejercicio");

            entity.HasOne(d => d.IdmaquinaNavigation).WithMany(p => p.Maquinaejercicios)
                .HasForeignKey(d => d.Idmaquina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinaejercicio_maquina");
        });

        modelBuilder.Entity<Movimientocaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientocaja_pkey");

            entity.ToTable("movimientocaja");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Concepto)
                .HasMaxLength(100)
                .HasColumnName("concepto");
            entity.Property(e => e.Esingreso).HasColumnName("esingreso");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcaja).HasColumnName("idcaja");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.IdmedioParametro).HasColumnName("idmedio_parametro");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Pagocon).HasColumnName("pagocon");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdcajaNavigation).WithMany(p => p.Movimientocajas)
                .HasForeignKey(d => d.Idcaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingresocaja_caja");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Movimientocajas)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingresocaja_idcliente");

            entity.HasOne(d => d.IdmedioParametroNavigation).WithMany(p => p.MovimientoCajaIdmedioParametroNavigations)
                .HasForeignKey(d => d.IdmedioParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimientoCaja_medio");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permiso_pkey");

            entity.ToTable("permiso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("puesto_pkey");

            entity.ToTable("puesto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
        });

        modelBuilder.Entity<Recursosejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recursosejercicio_pkey");

            entity.ToTable("recursosejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Ruta)
                .HasMaxLength(200)
                .HasColumnName("ruta");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Recursosejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recursosejercicio_ejercicio");
        });

        modelBuilder.Entity<Rutinacliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rutinacliente_pkey");

            entity.ToTable("rutinacliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(150)
                .HasColumnName("comentario");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Rutinaclientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinacliente_cliente");
        });

        modelBuilder.Entity<RutinaclienteDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rutinacliente_detalle_pkey");

            entity.ToTable("rutinacliente_detalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(150)
                .HasColumnName("comentario");
            entity.Property(e => e.Descansominutos).HasColumnName("descansominutos");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Idrutina).HasColumnName("idrutina");
            entity.Property(e => e.IdtiporutinaParametro).HasColumnName("idtiporutina_parametro");
            entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");
            entity.Property(e => e.Series).HasColumnName("series");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdrutinaNavigation).WithMany(p => p.RutinaclienteDetalles)
                .HasForeignKey(d => d.Idrutina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinacliente_detalle_cliente");

            entity.HasOne(d => d.IdtiporutinaParametroNavigation).WithMany(p => p.RutinaclienteDetalles)
                .HasForeignKey(d => d.IdtiporutinaParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinacliente_detalle_tiporutina");
        });

        modelBuilder.Entity<Rutinaejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rutinaejercicio_pkey");

            entity.ToTable("rutinaejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");
            entity.Property(e => e.Series).HasColumnName("series");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Rutinaejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinaejercicio_ejercicio");
        });

        modelBuilder.Entity<Suscripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suscripcion_pkey");

            entity.ToTable("suscripcion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.IdestadosuscripcionParametro).HasColumnName("idestadosuscripcion_parametro");
            entity.Property(e => e.IdtiposuscripcionParametro).HasColumnName("idtiposuscripcion_parametro");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Suscripcions)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripcion_cliente");

            entity.HasOne(d => d.IdestadosuscripcionParametroNavigation).WithMany(p => p.SuscripcionIdestadosuscripcionParametroNavigations)
                .HasForeignKey(d => d.IdestadosuscripcionParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripcion_estadosuscripcion");

            entity.HasOne(d => d.IdtiposuscripcionParametroNavigation).WithMany(p => p.SuscripcionIdtiposuscripcionParametroNavigations)
                .HasForeignKey(d => d.IdtiposuscripcionParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripcion_tiposuscripcion");
        });

        modelBuilder.Entity<Suscripciondetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suscripciondetalle_pkey");

            entity.ToTable("suscripciondetalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Fecharegistro");
            entity.Property(e => e.Fechafijapagada)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechafijapagada");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idmovimientocaja).HasColumnName("idmovimientocaja");
            entity.Property(e => e.Idsuscripcion).HasColumnName("idsuscripcion");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Pagocon).HasColumnName("pagocon");
            entity.Property(e => e.Periodofinpagado)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("periodofinpagado");
            entity.Property(e => e.Periodoiniciopagado)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("periodoiniciopagado");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("Usuarioregistro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");

            entity.HasOne(d => d.IdmovimientocajaNavigation).WithMany(p => p.Suscripciondetalles)
                .HasForeignKey(d => d.Idmovimientocaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripciondetalle_ingresocaja");

            entity.HasOne(d => d.IdsuscripcionNavigation).WithMany(p => p.Suscripciondetalles)
                .HasForeignKey(d => d.Idsuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripciondetalle_suscripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
