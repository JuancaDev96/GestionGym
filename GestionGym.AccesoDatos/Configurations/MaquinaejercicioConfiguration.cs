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
    public class MaquinaejercicioConfiguration : IEntityTypeConfiguration<Maquinaejercicio>
    {
        public void Configure(EntityTypeBuilder<Maquinaejercicio> entity)
        {
            entity.HasKey(e => e.Id).HasName("maquinaejercicio_pkey");

            entity.ToTable("maquinaejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Esmaquina).HasColumnName("esmaquina");
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
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Idmaquina).HasColumnName("idmaquina");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Maquinaejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinaejercicio_ejercicio");

            entity.HasOne(d => d.IdmaquinaNavigation).WithMany(p => p.Maquinaejercicios)
                .HasForeignKey(d => d.Idmaquina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinaejercicio_maquina");
        }
    }
}
