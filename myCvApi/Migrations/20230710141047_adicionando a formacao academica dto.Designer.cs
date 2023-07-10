﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myCvApi.Data;

#nullable disable

namespace myCvApi.Migrations
{
    [DbContext(typeof(LinguagemContext))]
    [Migration("20230710141047_adicionando a formacao academica dto")]
    partial class adicionandoaformacaoacademicadto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("myCvApi.Models.Formacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Formacoes");
                });

            modelBuilder.Entity("myCvApi.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FormacaoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDoConteudo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FormacaoId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("myCvApi.Models.Linguagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CorTexto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Linguagens");
                });

            modelBuilder.Entity("myCvApi.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("LinguagemId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("URLGithub")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("URLVisita")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LinguagemId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("myCvApi.Models.Grade", b =>
                {
                    b.HasOne("myCvApi.Models.Formacao", null)
                        .WithMany("Grade")
                        .HasForeignKey("FormacaoId");
                });

            modelBuilder.Entity("myCvApi.Models.Projeto", b =>
                {
                    b.HasOne("myCvApi.Models.Linguagem", "Linguagem")
                        .WithMany("Projetos")
                        .HasForeignKey("LinguagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Linguagem");
                });

            modelBuilder.Entity("myCvApi.Models.Formacao", b =>
                {
                    b.Navigation("Grade");
                });

            modelBuilder.Entity("myCvApi.Models.Linguagem", b =>
                {
                    b.Navigation("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}