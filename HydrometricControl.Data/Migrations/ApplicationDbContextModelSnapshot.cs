﻿// <auto-generated />
using System;
using HydrometricControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HydrometricControl.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbCondominio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(140);

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Condominio");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd16d46d-2cd7-4284-b9c6-699cf58c80bc"),
                            Ativo = true,
                            Cep = "72145902",
                            Cnpj = "11462759000102",
                            DataRegistro = new DateTime(2019, 7, 30, 16, 52, 31, 666, DateTimeKind.Local).AddTicks(594),
                            Endereco = "ST. SAGOCAN LT. 4 - Reserva Taguatinga",
                            ExclusaoLogica = false,
                            Nome = "Residencial Itamaraty",
                            Responsavel = "Railson Ramés Sousa",
                            Telefone = "6139727505"
                        });
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbConsumo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<DateTime>("Fim");

                    b.Property<Guid>("IdCondominio");

                    b.Property<Guid>("IdImposto");

                    b.Property<DateTime>("Inicio");

                    b.Property<double>("ValorExcedente");

                    b.Property<int>("VolumeExcedente");

                    b.HasKey("Id");

                    b.HasIndex("IdCondominio");

                    b.HasIndex("IdImposto");

                    b.ToTable("Consumo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f9a6fafa-7cf2-49db-877d-08e6210f3533"),
                            DataRegistro = new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(4211),
                            ExclusaoLogica = false,
                            Fim = new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(2083),
                            IdCondominio = new Guid("bd16d46d-2cd7-4284-b9c6-699cf58c80bc"),
                            IdImposto = new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"),
                            Inicio = new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(3147),
                            ValorExcedente = 0.0,
                            VolumeExcedente = 0
                        });
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbFaixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Aliquota");

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<Guid>("IdImposto");

                    b.Property<int>("Maximo");

                    b.Property<int>("Minimo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<int>("Ordem");

                    b.HasKey("Id");

                    b.HasIndex("IdImposto");

                    b.ToTable("Faixa");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f6369689-f501-4a21-a276-8b1420e15774"),
                            Aliquota = 2.8599999999999999,
                            Ativo = true,
                            DataRegistro = new DateTime(2019, 7, 30, 16, 52, 31, 665, DateTimeKind.Local).AddTicks(6936),
                            ExclusaoLogica = false,
                            IdImposto = new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"),
                            Maximo = 10,
                            Minimo = 0,
                            Nome = "Faixa 01",
                            Ordem = 1
                        });
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbImposto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Imposto");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"),
                            Ativo = true,
                            DataRegistro = new DateTime(2019, 7, 30, 16, 52, 31, 664, DateTimeKind.Local).AddTicks(5957),
                            ExclusaoLogica = false,
                            Nome = "Padrão CAESB 2016"
                        });
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbLeitura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<int>("HidrometroAnterior");

                    b.Property<int>("HidrometroAtual");

                    b.Property<Guid>("IdImposto");

                    b.Property<Guid>("IdUnidade");

                    b.Property<int>("MetrosCubicos");

                    b.Property<string>("NomeDaImagem")
                        .IsRequired()
                        .HasMaxLength(140);

                    b.Property<string>("Observacao");

                    b.Property<DateTime>("RealizadaEm");

                    b.HasKey("Id");

                    b.HasIndex("IdImposto");

                    b.HasIndex("IdUnidade");

                    b.ToTable("Leitura");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80d8a10d-8275-4b93-bb76-e9aa23ef25a3"),
                            DataRegistro = new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(385),
                            ExclusaoLogica = false,
                            HidrometroAnterior = 319,
                            HidrometroAtual = 327,
                            IdImposto = new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"),
                            IdUnidade = new Guid("a6edcd12-0b9a-4f0f-91f7-8f841d28286f"),
                            MetrosCubicos = 8,
                            NomeDaImagem = "",
                            Observacao = "Primeira leitura.",
                            RealizadaEm = new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(18)
                        });
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbLeituraGeral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataRealizacao");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<Guid>("IdCondominio");

                    b.Property<int>("MetrosCubicos");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCondominio");

                    b.ToTable("LeituraGeral");
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbUnidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Email")
                        .HasMaxLength(140);

                    b.Property<bool>("ExclusaoLogica");

                    b.Property<string>("Hidrometro")
                        .HasMaxLength(6);

                    b.Property<Guid>("IdCondominio");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("IdCondominio");

                    b.ToTable("Unidade");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6edcd12-0b9a-4f0f-91f7-8f841d28286f"),
                            Ativo = true,
                            Cpf = "72224709137",
                            DataRegistro = new DateTime(2019, 7, 30, 16, 52, 31, 666, DateTimeKind.Local).AddTicks(5174),
                            Email = "ryuchoa@hotmail.com",
                            ExclusaoLogica = false,
                            Hidrometro = "456789",
                            IdCondominio = new Guid("bd16d46d-2cd7-4284-b9c6-699cf58c80bc"),
                            Numero = "1608",
                            Responsavel = "Rayanne de Brito Uchoa",
                            Telefone = "6132225411"
                        });
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbConsumo", b =>
                {
                    b.HasOne("HydrometricControl.Data.Entities.TbCondominio", "TbCondominio")
                        .WithMany("TbConsumo")
                        .HasForeignKey("IdCondominio")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HydrometricControl.Data.Entities.TbImposto", "TbImposto")
                        .WithMany("TbConsumo")
                        .HasForeignKey("IdImposto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbFaixa", b =>
                {
                    b.HasOne("HydrometricControl.Data.Entities.TbImposto", "TbImposto")
                        .WithMany("TbFaixa")
                        .HasForeignKey("IdImposto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbLeitura", b =>
                {
                    b.HasOne("HydrometricControl.Data.Entities.TbImposto", "TbImposto")
                        .WithMany("TbLeitura")
                        .HasForeignKey("IdImposto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HydrometricControl.Data.Entities.TbUnidade", "TbUnidade")
                        .WithMany("TbLeitura")
                        .HasForeignKey("IdUnidade")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbLeituraGeral", b =>
                {
                    b.HasOne("HydrometricControl.Data.Entities.TbCondominio", "TbCondominio")
                        .WithMany("TbLeituraGeral")
                        .HasForeignKey("IdCondominio")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HydrometricControl.Data.Entities.TbUnidade", b =>
                {
                    b.HasOne("HydrometricControl.Data.Entities.TbCondominio", "TbCondominio")
                        .WithMany("TbUnidade")
                        .HasForeignKey("IdCondominio")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
