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
    public class HistorialmedicoClienteConfiguration : IEntityTypeConfiguration<HistorialmedicoCliente>
    {
        public void Configure(EntityTypeBuilder<HistorialmedicoCliente> entity)
        {
            entity.HasKey(e => e.Id).HasName("historialmedico_cliente_pkey");

            entity.ToTable("historialmedico_cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(100)
                .HasColumnName("comentario");
            entity.Property(e => e.Consideracion)
                .HasMaxLength(100)
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
            entity.Property(e => e.Idparametro).HasColumnName("idparametro");
            entity.Property(e => e.Recomendacion)
                .HasMaxLength(100)
                .HasColumnName("recomendacion");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");
            entity.Property(e => e.Valor)
                .HasMaxLength(30)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.HistorialmedicoClientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialmedico_cliente_cliente");

            entity.HasOne(d => d.IdparametroNavigation).WithMany(p => p.HistorialmedicoClientes)
                .HasForeignKey(d => d.Idparametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialmedico_cliente_maestrodetalle");
        }
    }
}
