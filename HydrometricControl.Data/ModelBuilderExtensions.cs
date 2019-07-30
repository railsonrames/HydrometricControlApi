using HydrometricControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HydrometricControl.Data
{

    public static class ModelBuilderExtensions
    {

        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {

            Guid _idFaixa = Guid.NewGuid();
            Guid _idImposto = Guid.NewGuid();
            Guid _idUnidade = Guid.NewGuid();
            Guid _idLeitura = Guid.NewGuid();
            Guid _idConsumo = Guid.NewGuid();
            Guid _idCondominio = Guid.NewGuid();

            modelBuilder.Entity<TbImposto>().HasData(
                new TbImposto
                {
                    Ativo = true,
                    Id = _idImposto,
                    ExclusaoLogica = false,
                    Nome = "Padrão CAESB 2016",
                    DataRegistro = DateTime.Now
                }
                );
            modelBuilder.Entity<TbFaixa>().HasData(
                new TbFaixa
                {
                    Id = _idFaixa,
                    Ordem = 1,
                    Minimo = 0,
                    Maximo = 10,
                    Ativo = true,
                    Aliquota = 2.86,
                    Nome = "Faixa 01",
                    IdImposto = _idImposto,
                    ExclusaoLogica = false,
                    DataRegistro = DateTime.Now
                }
                );
            modelBuilder.Entity<TbCondominio>().HasData(
                new TbCondominio
                {
                    Id = _idCondominio,
                    Ativo = true,
                    Cep = "72145902",
                    ExclusaoLogica = false,
                    Cnpj = "11462759000102",
                    Telefone = "6139727505",
                    DataRegistro = DateTime.Now,
                    Nome = "Residencial Itamaraty",
                    Responsavel = "Railson Ramés Sousa",
                    Endereco = "ST. SAGOCAN LT. 4 - Reserva Taguatinga"
                }
                );
            modelBuilder.Entity<TbUnidade>().HasData(
                new TbUnidade
                {
                    Id = _idUnidade,
                    Ativo = true,
                    Numero = "1608",
                    Cpf = "72224709137",
                    Hidrometro = "456789",
                    ExclusaoLogica = false,
                    Telefone = "6132225411",
                    DataRegistro = DateTime.Now,
                    IdCondominio = _idCondominio,
                    Email = "ryuchoa@hotmail.com",
                    Responsavel = "Rayanne de Brito Uchoa"
                }
                );
            modelBuilder.Entity<TbLeitura>().HasData(
                new TbLeitura
                {
                    Id = _idLeitura,
                    NomeDaImagem = "",
                    MetrosCubicos = 8,
                    HidrometroAtual = 327,
                    IdImposto = _idImposto,
                    IdUnidade = _idUnidade,
                    ExclusaoLogica = false,
                    HidrometroAnterior = 319,
                    RealizadaEm = DateTime.Now,
                    DataRegistro = DateTime.Now,
                    Observacao = "Primeira leitura.",
                }
                );
            modelBuilder.Entity<TbConsumo>().HasData(
                new TbConsumo
                {
                    Id = _idConsumo,
                    Fim = DateTime.Now,
                    ValorExcedente = 0,
                    VolumeExcedente = 0,
                    Inicio = DateTime.Now,
                    IdImposto = _idImposto,
                    ExclusaoLogica = false,
                    DataRegistro = DateTime.Now,
                    IdCondominio = _idCondominio
                }
                );

            return modelBuilder;

        }

    }

}
