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
    public class AplicacionejercicioConfiguration : IEntityTypeConfiguration<Aplicacionejercicio>
    {
        public void Configure(EntityTypeBuilder<Aplicacionejercicio> entity)
        {
            entity.HasKey(e => e.Id).HasName("aplicacionejercicio_pkey");

            entity.ToTable("aplicacionejercicio");

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
            entity.Property(e => e.IdaplicacionParametro).HasColumnName("idaplicacion_parametro");
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdaplicacionParametroNavigation).WithMany(p => p.Aplicacionejercicios)
                .HasForeignKey(d => d.IdaplicacionParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aplicacionejercicio_aplicacion");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Aplicacionejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aplicacionejercicio_ejercicio");
        }
    }
}
