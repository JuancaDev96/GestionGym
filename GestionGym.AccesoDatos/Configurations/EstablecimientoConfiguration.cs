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
    public class EstablecimientoConfiguration : IEntityTypeConfiguration<Establecimiento>
    {
        public void Configure(EntityTypeBuilder<Establecimiento> entity)
        {
            entity.HasKey(e => e.Id).HasName("establecimiento_pkey");

            entity.ToTable("establecimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Celular)
                .HasMaxLength(12)
                .HasColumnName("celular");
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
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
            entity.Property(e => e.Idempresa).HasColumnName("idempresa");
            entity.Property(e => e.Nombrecomercial)
                .HasMaxLength(50)
                .HasColumnName("nombrecomercial");
            entity.Property(e => e.Rutalogo)
                .HasMaxLength(200)
                .HasColumnName("rutalogo");
            entity.Property(e => e.Rutavideo)
                .HasMaxLength(200)
                .HasColumnName("rutavideo");
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(200)
                .HasColumnName("ubigeo");
            entity.Property(e => e.Urladicional)
                .HasMaxLength(200)
                .HasColumnName("urladicional");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdempresaNavigation).WithMany(p => p.Establecimientos)
                .HasForeignKey(d => d.Idempresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_establecimiento_empresa");
        }
    }
}
