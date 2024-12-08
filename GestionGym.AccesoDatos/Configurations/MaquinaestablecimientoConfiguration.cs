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
    public class MaquinaestablecimientoConfiguration : IEntityTypeConfiguration<Maquinaestablecimiento>
    {
        public void Configure(EntityTypeBuilder<Maquinaestablecimiento> entity)
        {
            entity.HasKey(e => e.Id).HasName("maquinaestablecimiento_pkey");

            entity.ToTable("maquinaestablecimiento");

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
            entity.Property(e => e.Idestablecimiento).HasColumnName("idestablecimiento");
            entity.Property(e => e.Idmaquina).HasColumnName("idmaquina");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdestablecimientoNavigation).WithMany(p => p.Maquinaestablecimientos)
                .HasForeignKey(d => d.Idestablecimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinaestabl_establecimiento");

            entity.HasOne(d => d.IdmaquinaNavigation).WithMany(p => p.Maquinaestablecimientos)
                .HasForeignKey(d => d.Idmaquina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinaestabl_maquina");
        }
    }
}
