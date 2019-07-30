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

    public class FaixaService : IFaixaService
    {

        private readonly ApplicationDbContext _contexto;
        private readonly IImpostoService _impostoService;

        public FaixaService(ApplicationDbContext contexto, IImpostoService impostoService)
        {
            _contexto = contexto;
            _impostoService = impostoService;
        }

        public async Task<int> Alterar(Guid? id, TbFaixa faixa)
        {
            _contexto.Faixa.Update(faixa);
            return await _contexto.SaveChangesAsync();
        }

        public Task<TbFaixa> Buscar(Guid? id)
        {
            return _contexto.Faixa.Include(x => x.TbImposto).Where(q => q.Id == id).FirstAsync();
        }

        public async Task<int> Criar(TbFaixa faixa)
        {
            faixa.DataRegistro = DateTime.Now;
            _contexto.Add(faixa);
            return await _contexto.SaveChangesAsync();
        }

        public Task<int> Excluir(TbFaixa faixa)
        {
            faixa.ExclusaoLogica = true;
            _contexto.Faixa.Update(faixa);
            return _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbFaixa>> Listar()
        {
            return await _contexto.Faixa
                .Include(x => x.TbImposto)
                .Where(x => !x.ExclusaoLogica)
                .ToListAsync();
        }

    }

}
