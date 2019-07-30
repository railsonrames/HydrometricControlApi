using System;
using System.Linq;
using System.Threading.Tasks;
using HydrometricControl.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HydrometricControl.Data.Models;
using HydrometricControl.Data.Entities;
using HydrometricControl.Domain.Interfaces;

namespace HydrometricControl.Domain.Services
{

    public class LeituraService : ILeituraService
    {

        private readonly ApplicationDbContext _contexto;

        public LeituraService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public Task<int> Alterar(Guid? id, TbLeitura leitura)
        {
            _contexto.Leitura.Update(leitura);
            return _contexto.SaveChangesAsync();
        }

        public async Task<TbLeitura> Buscar(Guid? id)
        {
            return await _contexto.Leitura
                .Include(x => x.TbUnidade)
                .Include(y => y.TbUnidade.TbCondominio)
                .Include(z => z.TbImposto)
                .Where(q => q.Id == id).FirstAsync();
        }

        public Task<int> Criar(TbLeitura leitura)
        {
            leitura.DataRegistro = DateTime.Now;
            _contexto.Add(leitura);
            return _contexto.SaveChangesAsync();
        }

        public Task<int> Excluir(TbLeitura leitura)
        {
            leitura.ExclusaoLogica = true;
            _contexto.Leitura.Update(leitura);
            return _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbLeitura>> Listar()
        {
            return await _contexto.Leitura
                .Include(x => x.TbUnidade)
                .Include(y => y.TbImposto)
                .Include(z => z.TbUnidade.TbCondominio)
                .Where(q => !q.ExclusaoLogica)
                .ToListAsync();
        }

        public async Task<IEnumerable<TbLeitura>> ListarInicial()
        {
            return await _contexto.Leitura
                .Include(x => x.TbUnidade)
                .Include(y => y.TbImposto)
                .Include(z => z.TbUnidade.TbCondominio)
                .Where(q => !q.ExclusaoLogica)
                .Take(10)
                .ToListAsync();
        }

        public async Task<IEnumerable<TbLeitura>> ListaFiltrada(FiltroLeituraData filtro)
        {
            return await _contexto.Leitura
                .Include(y => y.TbImposto)
                .Include(x => x.TbUnidade)
                .Include(z => z.TbUnidade.TbCondominio)
                .Where(q => !q.ExclusaoLogica
                    && (filtro.IdUnidade.HasValue ? q.IdUnidade == filtro.IdUnidade : true)
                    && (filtro.IdCondominio.HasValue ? q.TbUnidade.IdCondominio == filtro.IdCondominio : true)
                    && ((filtro.DataInicio.HasValue && filtro.DataFim.HasValue) ? q.RealizadaEm >= filtro.DataInicio && q.RealizadaEm <= filtro.DataFim : true))
                .ToListAsync();
        }

        public Task<int> SalvarListaLeituras(List<TbLeitura> leituras)
        {
            foreach (var leitura in leituras)
            {
                leitura.DataRegistro = DateTime.Now;
                _contexto.Add(leitura);
            }
            return _contexto.SaveChangesAsync();
        }

    }

}
