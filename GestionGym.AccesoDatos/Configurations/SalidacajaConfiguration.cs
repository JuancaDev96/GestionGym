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
    public class SalidacajaConfiguration : IEntityTypeConfiguration<Salidacaja>
    {
        public void Configure(EntityTypeBuilder<Salidacaja> entity)
        {
            entity.HasKey(e => e.Id).HasName("salidacaja_pkey");

            entity.ToTable("salidacaja");

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.IdmedioParametro).HasColumnName("idmedio_parametro");
            entity.Property(e => e.Idmovimiento).HasColumnName("idmovimiento");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdmedioParametroNavigation).WithMany(p => p.Salidacajas)
                .HasForeignKey(d => d.IdmedioParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_salidacaja_medio");

            entity.HasOne(d => d.IdmovimientoNavigation).WithMany(p => p.Salidacajas)
                .HasForeignKey(d => d.Idmovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_salidacaja_movimiento");
        }
    }
}
