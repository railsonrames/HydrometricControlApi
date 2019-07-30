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

    public class LeituraGeralService : ILeituraGeralService
    {

        private readonly ApplicationDbContext _contexto;

        public LeituraGeralService(ApplicationDbContext contexto)
            => _contexto = contexto;

        public Task<int> Criar(TbLeituraGeral leituraGeral)
        {
            leituraGeral.DataRegistro = DateTime.Now;
            _contexto.Add(leituraGeral);
            return _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbLeituraGeral>> Listar(Guid? idCondominio)
        {
            if (idCondominio == null || idCondominio == Guid.Empty)
                return await _contexto.LeituraGeral.ToListAsync();
            else
                return await _contexto.LeituraGeral.Where(x => x.IdCondominio == idCondominio).ToListAsync();
        }

        public async Task<TbLeituraGeral> Buscar(Guid? id)
        {
            return await _contexto.LeituraGeral
                .Include(x => x.TbCondominio)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Editar(TbLeituraGeral leituraGeral)
        {
            _contexto.LeituraGeral.Update(leituraGeral);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> Excluir(TbLeituraGeral leituraGeral)
        {
            leituraGeral.ExclusaoLogica = true;
            _contexto.LeituraGeral.Update(leituraGeral);
            return await _contexto.SaveChangesAsync();
        }

    }

}
