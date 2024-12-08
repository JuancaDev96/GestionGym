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
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> entity)
        {
            entity.HasKey(e => e.Id).HasName("empresa_pkey");

            entity.ToTable("empresa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Celular)
                .HasMaxLength(12)
                .HasColumnName("celular");
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccionfiscal)
                .HasMaxLength(50)
                .HasColumnName("direccionfiscal");
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
            entity.Property(e => e.Nombrecomercial)
                .HasMaxLength(50)
                .HasColumnName("nombrecomercial");
            entity.Property(e => e.Razonsocial)
                .HasMaxLength(50)
                .HasColumnName("razonsocial");
            entity.Property(e => e.Representante)
                .HasMaxLength(50)
                .HasColumnName("representante");
            entity.Property(e => e.Ruc)
                .HasMaxLength(12)
                .HasColumnName("ruc");
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
            entity.Property(e => e.Urlfacebook)
                .HasMaxLength(200)
                .HasColumnName("urlfacebook");
            entity.Property(e => e.Urlinstagram)
                .HasMaxLength(200)
                .HasColumnName("urlinstagram");
            entity.Property(e => e.Urltiktok)
                .HasMaxLength(200)
                .HasColumnName("urltiktok");
            entity.Property(e => e.Usuariomodificacion)
                .HasMaxLength(50)
                .HasColumnName("usuariomodificacion");
            entity.Property(e => e.Usuarioregistro)
                .HasMaxLength(50)
                .HasDefaultValueSql("'consola'::character varying")
                .HasColumnName("usuarioregistro");
        }
    }
}
