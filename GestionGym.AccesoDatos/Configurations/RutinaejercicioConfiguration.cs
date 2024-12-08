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
    public class RutinaejercicioConfiguration : IEntityTypeConfiguration<Rutinaejercicio>
    {
        public void Configure(EntityTypeBuilder<Rutinaejercicio> entity)
        {
            entity.HasKey(e => e.Id).HasName("rutinaejercicio_pkey");

            entity.ToTable("rutinaejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
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
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");
            entity.Property(e => e.Series).HasColumnName("series");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Rutinaejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinaejercicio_ejercicio");
        }
    }
}
