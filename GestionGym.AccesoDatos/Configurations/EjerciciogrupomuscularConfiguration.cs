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
    public class EjerciciogrupomuscularConfiguration : IEntityTypeConfiguration<Ejerciciogrupomuscular>
    {
        public void Configure(EntityTypeBuilder<Ejerciciogrupomuscular> entity)
        {
            entity.HasKey(e => e.Id).HasName("ejerciciogrupomuscular_pkey");

            entity.ToTable("ejerciciogrupomuscular");

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
            entity.Property(e => e.IdgrupomuscularParametro).HasColumnName("idgrupomuscular_parametro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdejercicioNavigation).WithMany(p => p.Ejerciciogrupomusculars)
                .HasForeignKey(d => d.Idejercicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ejerciciogrupomuscular_ejercicio");

            entity.HasOne(d => d.IdgrupomuscularParametroNavigation).WithMany(p => p.Ejerciciogrupomusculars)
                .HasForeignKey(d => d.IdgrupomuscularParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ejerciciogrupomuscular_grupomuscular");
        }
    }
}
