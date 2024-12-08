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
    public class RecursosmaquinaConfiguration : IEntityTypeConfiguration<Recursosmaquina>
    {
        public void Configure(EntityTypeBuilder<Recursosmaquina> entity)
        {
            entity.HasKey(e => e.Id).HasName("recursosmaquina_pkey");

            entity.ToTable("recursosmaquina");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Camporeservado)
                .HasMaxLength(200)
                .HasColumnName("camporeservado");
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
            entity.Property(e => e.Idmaquina).HasColumnName("idmaquina");
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

            entity.HasOne(d => d.IdmaquinaNavigation).WithMany(p => p.Recursosmaquinas)
                .HasForeignKey(d => d.Idmaquina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_recursosmaquinao_maquina");
        }
    }
}
