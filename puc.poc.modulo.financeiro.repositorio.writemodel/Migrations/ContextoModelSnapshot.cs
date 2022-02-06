﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using puc.poc.modulo.financeiro.repositorio.writemodel;

namespace puc.poc.modulo.financeiro.repositorio.writemodel.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("puc.poc.modulo.financeiro.dominio.WriteModel.Associado", b =>
                {
                    b.Property<string>("UniqueId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UniqueId");

                    b.ToTable("Associados");
                });

            modelBuilder.Entity("puc.poc.modulo.financeiro.dominio.WriteModel.Boleto", b =>
                {
                    b.Property<string>("UniqueId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssociadoUniqueId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Banco")
                        .HasColumnType("longtext");

                    b.Property<int>("CodigoBarras")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("UniqueId");

                    b.HasIndex("AssociadoUniqueId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("puc.poc.modulo.financeiro.dominio.WriteModel.Boleto", b =>
                {
                    b.HasOne("puc.poc.modulo.financeiro.dominio.WriteModel.Associado", "Associado")
                        .WithMany("Boletos")
                        .HasForeignKey("AssociadoUniqueId");

                    b.Navigation("Associado");
                });

            modelBuilder.Entity("puc.poc.modulo.financeiro.dominio.WriteModel.Associado", b =>
                {
                    b.Navigation("Boletos");
                });
#pragma warning restore 612, 618
        }
    }
}