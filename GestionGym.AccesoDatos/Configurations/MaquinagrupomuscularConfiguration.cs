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
    public class MaquinagrupomuscularConfiguration : IEntityTypeConfiguration<Maquinagrupomuscular>
    {
        public void Configure(EntityTypeBuilder<Maquinagrupomuscular> entity)
        {
            entity.HasKey(e => e.Id).HasName("maquinagrupomuscular_pkey");

            entity.ToTable("maquinagrupomuscular");

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
            entity.Property(e => e.IdgrupomuscularParametro).HasColumnName("idgrupomuscular_parametro");
            entity.Property(e => e.Idmaquina).HasColumnName("idmaquina");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdgrupomuscularParametroNavigation).WithMany(p => p.Maquinagrupomusculars)
                .HasForeignKey(d => d.IdgrupomuscularParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinagrupomuscular_grupomuscular");

            entity.HasOne(d => d.IdmaquinaNavigation).WithMany(p => p.Maquinagrupomusculars)
                .HasForeignKey(d => d.Idmaquina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_maquinagrupomuscular_maquina");
        }
    }
}
