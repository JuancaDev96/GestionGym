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
    public class FichaclienteConfiguration : IEntityTypeConfiguration<Fichacliente>
    {
        public void Configure(EntityTypeBuilder<Fichacliente> entity)
        {
            entity.HasKey(e => e.Id).HasName("fichacliente_pkey");

            entity.ToTable("fichacliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechainicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.IdnivelParametro).HasColumnName("idnivel_parametro");
            entity.Property(e => e.IdobjetivoParametro).HasColumnName("idobjetivo_parametro");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Fichaclientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fichacliente_cliente");

            entity.HasOne(d => d.IdnivelParametroNavigation).WithMany(p => p.FichaclienteIdnivelParametroNavigations)
                .HasForeignKey(d => d.IdnivelParametro)
                .HasConstraintName("fk_fichacliente_nivel_parametro");

            entity.HasOne(d => d.IdobjetivoParametroNavigation).WithMany(p => p.FichaclienteIdobjetivoParametroNavigations)
                .HasForeignKey(d => d.IdobjetivoParametro)
                .HasConstraintName("fk_ficha_objetivo_parametro");
        }
    }
}
