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
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> entity)
        {
            entity.HasKey(e => e.Id).HasName("colaborador_pkey");

            entity.ToTable("colaborador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correoelectronico)
                .HasMaxLength(100)
                .HasColumnName("correoelectronico");
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
            entity.Property(e => e.Idestablecimiento).HasColumnName("idestablecimiento");
            entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdestablecimientoNavigation).WithMany(p => p.Colaboradors)
                .HasForeignKey(d => d.Idestablecimiento)
                .HasConstraintName("fk_colaborador_establimiento");

            entity.HasOne(d => d.IdpuestoNavigation).WithMany(p => p.Colaboradors)
                .HasForeignKey(d => d.Idpuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaborador_puesto");
        }
    }
}
