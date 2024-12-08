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
    public class RutinaclienteDetalleConfiguration : IEntityTypeConfiguration<RutinaclienteDetalle>
    {
        public void Configure(EntityTypeBuilder<RutinaclienteDetalle> entity)
        {
            entity.HasKey(e => e.Id).HasName("rutinacliente_detalle_pkey");

            entity.ToTable("rutinacliente_detalle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(150)
                .HasColumnName("comentario");
            entity.Property(e => e.Descansominutos).HasColumnName("descansominutos");
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
            entity.Property(e => e.Idejercicio).HasColumnName("idejercicio");
            entity.Property(e => e.Idrutina).HasColumnName("idrutina");
            entity.Property(e => e.IdtiporutinaParametro).HasColumnName("idtiporutina_parametro");
            entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");
            entity.Property(e => e.Series).HasColumnName("series");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");

            entity.HasOne(d => d.IdrutinaNavigation).WithMany(p => p.RutinaclienteDetalles)
                .HasForeignKey(d => d.Idrutina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinacliente_detalle_cliente");

            entity.HasOne(d => d.IdtiporutinaParametroNavigation).WithMany(p => p.RutinaclienteDetalles)
                .HasForeignKey(d => d.IdtiporutinaParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rutinacliente_detalle_tiporutina");
        }
    }
}
