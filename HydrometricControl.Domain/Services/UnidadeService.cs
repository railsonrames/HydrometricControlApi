using HydrometricControl.Data;
using HydrometricControl.Data.Entities;
using HydrometricControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydrometricControl.Domain.Services
{

    public class UnidadeService : IUnidadeService
    {

        private readonly ApplicationDbContext _contexto;
        private readonly ICondominioService _condominioService;

        public UnidadeService(ApplicationDbContext contexto, ICondominioService condominioService)
        {
            _contexto = contexto;
            _condominioService = condominioService;
        }

        public async Task<IEnumerable<TbUnidade>> Listar()
        {
            //GeradorDeUnidades();
            return await _contexto.Unidade
                .Include(x => x.TbCondominio)
                .Where(x => !x.ExclusaoLogica)
                .OrderBy(x => x.Numero)
                .ToListAsync();
        }

        public async Task<int> Alterar(Guid? id, TbUnidade unidade)
        {
            _contexto.Unidade.Update(unidade);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<TbUnidade> Buscar(Guid? id)
        {
            return await _contexto.Unidade.Include(x => x.TbCondominio).Where(q => q.Id == id).FirstAsync();
        }

        public TbUnidade BuscarBeta(Guid id)
        {
            return _contexto.Unidade.Include(x => x.TbCondominio).Where(q => q.Id == id).First();
        }

        public async Task<int> Criar(TbUnidade unidade)
        {
            unidade.DataRegistro = DateTime.Now;
            _contexto.Add(unidade);
            return await _contexto.SaveChangesAsync();
        }

        public void CriarSincrono(TbUnidade unidade)
        {
            unidade.DataRegistro = DateTime.Now;
            _contexto.Add(unidade);
            _contexto.SaveChanges();
        }

        public async Task<int> Excluir(TbUnidade unidade)
        {
            unidade.ExclusaoLogica = true;
            _contexto.Unidade.Update(unidade);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbUnidade>> ListarPorCondominio(Guid idCondominio)
        {
            return await _contexto.Unidade
                .Include(x => x.TbCondominio)
                .Where(y => y.TbCondominio.Id == idCondominio)
                .ToListAsync();
        }

        public void GeradorDeUnidades()
        {
            char[] blocos = Enumerable.Range('A', 'N' - 'A' + 1).Select(i => (Char)i).ToArray();
            //int andares = 4;
            //int unidades = 4;
            int contadorResponsavel = 0;

            TbUnidade novaUnidade = new TbUnidade();

            //for (int b = 0; b < blocos.Length; b++)
            //{
            //    for (int a = 1; a <= andares; a++)
            //    {
            //        for (int u = 1; u <= unidades; u++)
            //        {
            //            novaUnidade.Id = Guid.NewGuid();
            //            novaUnidade.Numero = $"{blocos[b]}-{a}0{u}";
            //            novaUnidade.Responsavel = $"Nome Fictício {++contadorResponsavel}";
            //            novaUnidade.Cpf = $"000{contadorResponsavel}";
            //            novaUnidade.Ativo = true;
            //            novaUnidade.Email = $"email.ficticio.{contadorResponsavel}@gmail.com";
            //            novaUnidade.Hidrometro = (48965 + contadorResponsavel).ToString();
            //            novaUnidade.IdCondominio = new Guid("fd8cbc36-b809-4b44-288d-08d70a34d130");
            //            novaUnidade.Telefone = $"3375-0{contadorResponsavel}";
            //            CriarSincrono(novaUnidade);
            //        }
            //    }
            //}
            //string formato = "";
            //for (int casa = 1; casa <= 86; casa++)
            //{
            //    novaUnidade.Id = Guid.NewGuid();
            //    formato = casa < 10 ? $"0{casa}" : casa.ToString();
            //    novaUnidade.Numero = "CASA-"+formato;
            //    novaUnidade.Responsavel = $"Nome Fictício {++contadorResponsavel}";
            //    novaUnidade.Cpf = $"000{contadorResponsavel}";
            //    novaUnidade.Ativo = true;
            //    novaUnidade.Email = $"email.ficticio.{contadorResponsavel}@gmail.com";
            //    novaUnidade.Hidrometro = (48965 + contadorResponsavel).ToString();
            //    novaUnidade.IdCondominio = new Guid("fd8cbc36-b809-4b44-288d-08d70a34d130");
            //    novaUnidade.Telefone = $"3375-0{contadorResponsavel}";
            //    CriarSincrono(novaUnidade);
            //}

            for (int b = 0; b < blocos.Length; b++)
            {
                novaUnidade.Id = Guid.NewGuid();
                novaUnidade.Numero = $"{blocos[b]}-Lixeira";
                novaUnidade.Responsavel = $"Nome Fictício {++contadorResponsavel}";
                novaUnidade.Cpf = $"000{contadorResponsavel}";
                novaUnidade.Ativo = true;
                novaUnidade.Email = $"email.ficticio.{contadorResponsavel}@gmail.com";
                novaUnidade.Hidrometro = (48965 + contadorResponsavel).ToString();
                novaUnidade.IdCondominio = new Guid("fd8cbc36-b809-4b44-288d-08d70a34d130");
                novaUnidade.Telefone = $"3375-0{contadorResponsavel}";
                CriarSincrono(novaUnidade);
            }

        }

    }

}
