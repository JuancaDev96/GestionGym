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
    public class RecursosejercicioConfiguration : IEntityTypeConfiguration<Recursosejercicio>
    {
        public void Configure(EntityTypeBuilder<Recursosejercicio> entity)
        {
            entity.HasKey(e => e.Id).HasName("recursosejercicio_pkey");

            entity.ToTable("recursosejercicio");

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
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.IdTipoRecurso).HasColumnName("idtiporecurso_parametro");
            entity.Property(e => e.Ruta)
                .HasMaxLength(200)
                .HasColumnName("ruta");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Recursosejercicios)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recursosejercicio_ejercicio");

            entity.HasOne(d => d.IdtiporecursoParametroNavigation).WithMany(p => p.Recursosejercicios)
                .HasForeignKey(d => d.IdTipoRecurso)
                .HasConstraintName("fk_recursoejercicio_tiporecurso_parametro");
        }
    }
}
