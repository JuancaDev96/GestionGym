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
    public class ColaboradorusuariopermisoConfiguration : IEntityTypeConfiguration<Colaboradorusuariopermiso>
    {
        public void Configure(EntityTypeBuilder<Colaboradorusuariopermiso> entity)
        {
            entity.HasKey(e => e.Id).HasName("colaboradorusuariopermiso_pkey");

            entity.ToTable("colaboradorusuariopermiso");

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
            entity.Property(e => e.Idcolaboradorusuario).HasColumnName("idcolaboradorusuario");
            entity.Property(e => e.Idpermiso).HasColumnName("idpermiso");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdcolaboradorusuarioNavigation).WithMany(p => p.Colaboradorusuariopermisos)
                .HasForeignKey(d => d.Idcolaboradorusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuariopermiso_colaboradorusuario");

            entity.HasOne(d => d.IdpermisoNavigation).WithMany(p => p.Colaboradorusuariopermisos)
                .HasForeignKey(d => d.Idpermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_colaboradorusuariopermiso_permiso");
        }
    }
}
