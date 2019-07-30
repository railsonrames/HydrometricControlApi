using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HydrometricControl.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 70, nullable: false),
                    Endereco = table.Column<string>(maxLength: 140, nullable: false),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    Responsavel = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imposto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imposto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeituraGeral",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MetrosCubicos = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false),
                    IdCondominio = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeituraGeral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeituraGeral_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(maxLength: 12, nullable: false),
                    Hidrometro = table.Column<string>(maxLength: 6, nullable: true),
                    Responsavel = table.Column<string>(maxLength: 70, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 140, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false),
                    IdCondominio = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidade_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    ValorExcedente = table.Column<double>(nullable: false),
                    VolumeExcedente = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false),
                    IdImposto = table.Column<Guid>(nullable: false),
                    IdCondominio = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumo_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumo_Imposto_IdImposto",
                        column: x => x.IdImposto,
                        principalTable: "Imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faixa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 70, nullable: false),
                    Minimo = table.Column<int>(nullable: false),
                    Maximo = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    Aliquota = table.Column<double>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false),
                    IdImposto = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faixa_Imposto_IdImposto",
                        column: x => x.IdImposto,
                        principalTable: "Imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leitura",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RealizadaEm = table.Column<DateTime>(nullable: false),
                    MetrosCubicos = table.Column<int>(nullable: false),
                    HidrometroAtual = table.Column<int>(nullable: false),
                    HidrometroAnterior = table.Column<int>(nullable: false),
                    NomeDaImagem = table.Column<string>(maxLength: 140, nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    ExclusaoLogica = table.Column<bool>(nullable: false),
                    IdUnidade = table.Column<Guid>(nullable: false),
                    IdImposto = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leitura_Imposto_IdImposto",
                        column: x => x.IdImposto,
                        principalTable: "Imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leitura_Unidade_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Condominio",
                columns: new[] { "Id", "Ativo", "Cep", "Cnpj", "DataRegistro", "Endereco", "ExclusaoLogica", "Nome", "Responsavel", "Telefone" },
                values: new object[] { new Guid("bd16d46d-2cd7-4284-b9c6-699cf58c80bc"), true, "72145902", "11462759000102", new DateTime(2019, 7, 30, 16, 52, 31, 666, DateTimeKind.Local).AddTicks(594), "ST. SAGOCAN LT. 4 - Reserva Taguatinga", false, "Residencial Itamaraty", "Railson Ramés Sousa", "6139727505" });

            migrationBuilder.InsertData(
                table: "Imposto",
                columns: new[] { "Id", "Ativo", "DataRegistro", "ExclusaoLogica", "Nome" },
                values: new object[] { new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"), true, new DateTime(2019, 7, 30, 16, 52, 31, 664, DateTimeKind.Local).AddTicks(5957), false, "Padrão CAESB 2016" });

            migrationBuilder.InsertData(
                table: "Consumo",
                columns: new[] { "Id", "DataRegistro", "ExclusaoLogica", "Fim", "IdCondominio", "IdImposto", "Inicio", "ValorExcedente", "VolumeExcedente" },
                values: new object[] { new Guid("f9a6fafa-7cf2-49db-877d-08e6210f3533"), new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(4211), false, new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(2083), new Guid("bd16d46d-2cd7-4284-b9c6-699cf58c80bc"), new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"), new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(3147), 0.0, 0 });

            migrationBuilder.InsertData(
                table: "Faixa",
                columns: new[] { "Id", "Aliquota", "Ativo", "DataRegistro", "ExclusaoLogica", "IdImposto", "Maximo", "Minimo", "Nome", "Ordem" },
                values: new object[] { new Guid("f6369689-f501-4a21-a276-8b1420e15774"), 2.8599999999999999, true, new DateTime(2019, 7, 30, 16, 52, 31, 665, DateTimeKind.Local).AddTicks(6936), false, new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"), 10, 0, "Faixa 01", 1 });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Ativo", "Cpf", "DataRegistro", "Email", "ExclusaoLogica", "Hidrometro", "IdCondominio", "Numero", "Responsavel", "Telefone" },
                values: new object[] { new Guid("a6edcd12-0b9a-4f0f-91f7-8f841d28286f"), true, "72224709137", new DateTime(2019, 7, 30, 16, 52, 31, 666, DateTimeKind.Local).AddTicks(5174), "ryuchoa@hotmail.com", false, "456789", new Guid("bd16d46d-2cd7-4284-b9c6-699cf58c80bc"), "1608", "Rayanne de Brito Uchoa", "6132225411" });

            migrationBuilder.InsertData(
                table: "Leitura",
                columns: new[] { "Id", "DataRegistro", "ExclusaoLogica", "HidrometroAnterior", "HidrometroAtual", "IdImposto", "IdUnidade", "MetrosCubicos", "NomeDaImagem", "Observacao", "RealizadaEm" },
                values: new object[] { new Guid("80d8a10d-8275-4b93-bb76-e9aa23ef25a3"), new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(385), false, 319, 327, new Guid("ce7958ae-094a-422e-9cb7-efc7e8d537c0"), new Guid("a6edcd12-0b9a-4f0f-91f7-8f841d28286f"), 8, "", "Primeira leitura.", new DateTime(2019, 7, 30, 16, 52, 31, 667, DateTimeKind.Local).AddTicks(18) });

            migrationBuilder.CreateIndex(
                name: "IX_Consumo_IdCondominio",
                table: "Consumo",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_Consumo_IdImposto",
                table: "Consumo",
                column: "IdImposto");

            migrationBuilder.CreateIndex(
                name: "IX_Faixa_IdImposto",
                table: "Faixa",
                column: "IdImposto");

            migrationBuilder.CreateIndex(
                name: "IX_Leitura_IdImposto",
                table: "Leitura",
                column: "IdImposto");

            migrationBuilder.CreateIndex(
                name: "IX_Leitura_IdUnidade",
                table: "Leitura",
                column: "IdUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_LeituraGeral_IdCondominio",
                table: "LeituraGeral",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdCondominio",
                table: "Unidade",
                column: "IdCondominio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumo");

            migrationBuilder.DropTable(
                name: "Faixa");

            migrationBuilder.DropTable(
                name: "Leitura");

            migrationBuilder.DropTable(
                name: "LeituraGeral");

            migrationBuilder.DropTable(
                name: "Imposto");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Condominio");
        }
    }
}
