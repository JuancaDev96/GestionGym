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
    public class InformeinstructorConfiguration : IEntityTypeConfiguration<Informeinstructor>
    {
        public void Configure(EntityTypeBuilder<Informeinstructor> entity)
        {
            entity.HasKey(e => e.Id).HasName("informeinstructor_pkey");

            entity.ToTable("informeinstructor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(300)
                .HasColumnName("comentario");
            entity.Property(e => e.Consideracion)
                .HasMaxLength(300)
                .HasColumnName("consideracion");
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
            entity.Property(e => e.Idinstructor).HasColumnName("idinstructor");
            entity.Property(e => e.Nivel).HasColumnName("nivel");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Informeinstructors)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_informeinstructor_cliente");

            entity.HasOne(d => d.IdinstructorNavigation).WithMany(p => p.Informeinstructors)
                .HasForeignKey(d => d.Idinstructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_informeinstructor_instructor");
        }
    }
}
