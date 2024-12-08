using GestionGym.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.AccesoDatos.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.Id).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Dni, "cliente_unique").IsUnique();

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
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fechanacimiento).HasColumnName("fechanacimiento");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idestablecimiento).HasColumnName("idestablecimiento");
            entity.Property(e => e.Idgenero).HasColumnName("idgenero_parametro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdestablecimientoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idestablecimiento)
                .HasConstraintName("fk_cliente_establecimiento");

            entity.HasOne(d => d.IdgeneroParametroNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idgenero)
                .HasConstraintName("fk_cliente_genero");
        }
    }
}
