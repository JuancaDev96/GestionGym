﻿using GestionGym.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.AccesoDatos.Configurations
{
    public class EjercicioConfiguration : IEntityTypeConfiguration<Ejercicio>
    {
        public void Configure(EntityTypeBuilder<Ejercicio> entity)
        {
            entity.HasKey(e => e.Id).HasName("ejercicio_pkey");

            entity.ToTable("ejercicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
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
            entity.Property(e => e.IdEstablecimiento).HasColumnName("idestablecimiento");
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

            entity.HasOne(d => d.IdestablecimientoNavigation).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.IdEstablecimiento)
                .HasConstraintName("fk_ejercicio_establecimiento");
        }
    }
}