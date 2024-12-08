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
    public class ColaboradorusuarioConfiguration : IEntityTypeConfiguration<Colaboradorusuario>
    {
        public void Configure(EntityTypeBuilder<Colaboradorusuario> entity)
        {
            entity.HasKey(e => e.Id).HasName("colaboradorusuario_pkey");

            entity.ToTable("colaboradorusuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bloqueadohasta)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("bloqueadohasta");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
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
            entity.Property(e => e.Idcolaborador).HasColumnName("idcolaborador");
            entity.Property(e => e.Intentosfallidos).HasColumnName("intentosfallidos");
            entity.Property(e => e.Ultimobloqueo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimobloqueo");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdcolaboradorNavigation).WithMany(p => p.Colaboradorusuarios)
                .HasForeignKey(d => d.Idcolaborador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuario_colaborador");
        }
    }
}
