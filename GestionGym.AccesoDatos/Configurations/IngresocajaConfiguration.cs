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
    public class IngresocajaConfiguration : IEntityTypeConfiguration<Ingresocaja>
    {
        public void Configure(EntityTypeBuilder<Ingresocaja> entity)
        {
            entity.HasKey(e => e.Id).HasName("ingresocaja_pkey");

            entity.ToTable("ingresocaja");

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
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.IdmedioParametro).HasColumnName("idmedio_parametro");
            entity.Property(e => e.Idmovimiento).HasColumnName("idmovimiento");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Pagocon).HasColumnName("pagocon");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Ingresocajas)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingresocaja_idcliente");

            entity.HasOne(d => d.IdmedioParametroNavigation).WithMany(p => p.Ingresocajas)
                .HasForeignKey(d => d.IdmedioParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingresocaja_medio");

            entity.HasOne(d => d.IdmovimientoNavigation).WithMany(p => p.Ingresocajas)
                .HasForeignKey(d => d.Idmovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingresocaja_movimiento");
        }
    }
}
