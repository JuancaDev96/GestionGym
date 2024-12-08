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
    public class MovimientocajaConfiguration : IEntityTypeConfiguration<Movimientocaja>
    {
        public void Configure(EntityTypeBuilder<Movimientocaja> entity)
        {
            entity.HasKey(e => e.Id).HasName("movimientocaja_pkey");

            entity.ToTable("movimientocaja");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Concepto)
                .HasMaxLength(100)
                .HasColumnName("concepto");
            entity.Property(e => e.Correlativo)
                .HasMaxLength(20)
                .HasColumnName("correlativo");
            entity.Property(e => e.Esingreso).HasColumnName("esingreso");
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
            entity.Property(e => e.Idcaja).HasColumnName("idcaja");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdcajaNavigation).WithMany(p => p.Movimientocajas)
                .HasForeignKey(d => d.Idcaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimientocaja_caja");
        }
    }
}
