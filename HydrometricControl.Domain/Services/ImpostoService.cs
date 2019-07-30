using HydrometricControl.Data;
using HydrometricControl.Data.Entities;
using HydrometricControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrometricControl.Domain.Services
{

    public class ImpostoService : IImpostoService
    {

        private readonly ApplicationDbContext _contexto;

        public ImpostoService(ApplicationDbContext contexto)
            => _contexto = contexto;

        public Task<int> Alterar(Guid? id, TbImposto imposto)
        {
            _contexto.Imposto.Update(imposto);
            return _contexto.SaveChangesAsync();
        }

        public async Task<TbImposto> Buscar(Guid? id)
        {
            return await _contexto.Imposto.FindAsync(id);
        }

        public Task<int> Criar(TbImposto imposto)
        {
            imposto.DataRegistro = DateTime.Now;
            _contexto.Add(imposto);
            return _contexto.SaveChangesAsync();
        }

        public Task<int> Excluir(TbImposto imposto)
        {
            imposto.ExclusaoLogica = true;
            _contexto.Imposto.Update(imposto);
            return _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbImposto>> Listar()
        {
            return await _contexto.Imposto.Where(x => !x.ExclusaoLogica).ToListAsync();
        }

    }

}
