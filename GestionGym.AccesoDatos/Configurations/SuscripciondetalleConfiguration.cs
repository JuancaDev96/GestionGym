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
    public class SuscripciondetalleConfiguration : IEntityTypeConfiguration<Suscripciondetalle>
    {
        public void Configure(EntityTypeBuilder<Suscripciondetalle> entity)
        {
            entity.HasKey(e => e.Id).HasName("suscripciondetalle_pkey");

            entity.ToTable("suscripciondetalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechafijapagada)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechafijapagada");
            entity.Property(e => e.Fechamodificacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idmovimientocaja).HasColumnName("idmovimientocaja");
            entity.Property(e => e.Idsuscripcion).HasColumnName("idsuscripcion");
            entity.Property(e => e.Periodofinpagado)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("periodofinpagado");
            entity.Property(e => e.Periodoiniciopagado)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("periodoiniciopagado");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdmovimientocajaNavigation).WithMany(p => p.Suscripciondetalles)
                .HasForeignKey(d => d.Idmovimientocaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripciondetalle_ingresocaja");

            entity.HasOne(d => d.IdsuscripcionNavigation).WithMany(p => p.Suscripciondetalles)
                .HasForeignKey(d => d.Idsuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suscripciondetalle_suscripcion");
        }
    }
}
