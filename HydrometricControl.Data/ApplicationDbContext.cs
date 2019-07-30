using HydrometricControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HydrometricControl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        public DbSet<TbFaixa> Faixa { get; set; }
        public DbSet<TbImposto> Imposto { get; set; }
        public DbSet<TbUnidade> Unidade { get; set; }
        public DbSet<TbLeitura> Leitura { get; set; }
        public DbSet<TbConsumo> Consumo { get; set; }
        public DbSet<TbCondominio> Condominio { get; set; }
        public DbSet<TbLeituraGeral> LeituraGeral { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
