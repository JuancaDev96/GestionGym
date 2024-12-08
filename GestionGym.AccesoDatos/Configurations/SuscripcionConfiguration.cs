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
    public class SuscripcionConfiguration : IEntityTypeConfiguration<Suscripcion>
    {
        public void Configure(EntityTypeBuilder<Suscripcion> entity)
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
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idestadosuscripcion).HasColumnName("idestadosuscripcion_parametro");
            entity.Property(e => e.Idpreciosuscripcion).HasColumnName("idpreciosuscripcion");
            entity.Property(e => e.Idtiposuscripcion).HasColumnName("idtiposuscripcion_parametro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Suscripcions)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripcion_cliente");

            entity.HasOne(d => d.IdestadosuscripcionParametroNavigation).WithMany(p => p.SuscripcionIdestadosuscripcionParametroNavigations)
                .HasForeignKey(d => d.Idestadosuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripcion_estadosuscripcion");

            entity.HasOne(d => d.IdpreciosuscripcionNavigation).WithMany(p => p.Suscripcions)
                .HasForeignKey(d => d.Idpreciosuscripcion)
                .HasConstraintName("fk_suscripcion_precio");

            entity.HasOne(d => d.IdtiposuscripcionParametroNavigation).WithMany(p => p.SuscripcionIdtiposuscripcionParametroNavigations)
                .HasForeignKey(d => d.Idtiposuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripcion_tiposuscripcion");
        }
    }
}
