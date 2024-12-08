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
    public class PreciossuscripcionConfiguration : IEntityTypeConfiguration<Preciossuscripcion>
    {
        public void Configure(EntityTypeBuilder<Preciossuscripcion> entity)
        {
            entity.HasKey(e => e.Id).HasName("preciossuscripcion_pkey");

            entity.ToTable("preciossuscripcion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
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
            entity.Property(e => e.IdtiposuscripcionParametro).HasColumnName("idtiposuscripcion_parametro");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdtiposuscripcionParametroNavigation).WithMany(p => p.Preciossuscripcions)
                .HasForeignKey(d => d.IdtiposuscripcionParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_preciossuscripcion_tiposuscripcion");
        }
    }
}
