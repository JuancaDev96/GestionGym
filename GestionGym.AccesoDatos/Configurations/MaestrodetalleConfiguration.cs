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
    public class MaestrodetalleConfiguration : IEntityTypeConfiguration<Maestrodetalle>
    {
        public void Configure(EntityTypeBuilder<Maestrodetalle> entity)
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
            entity.Property(e => e.Esbool)
                .HasDefaultValue(false)
                .HasColumnName("esbool");
            entity.Property(e => e.Esdefault)
                .HasDefaultValue(false)
                .HasComment("Define si el parametro se utilizaria sin necesidad de seleccionarlo")
                .HasColumnName("esdefault");
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
            entity.Property(e => e.Idmaestro).HasColumnName("idmaestro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");
            entity.Property(e => e.Valor)
                .HasMaxLength(150)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdmaestroNavigation).WithMany(p => p.Maestrodetalles)
                .HasForeignKey(d => d.Idmaestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maestrodetalle_maestro");
        }
    }
}
