using System;
using System.Linq;
using System.Threading.Tasks;
using HydrometricControl.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HydrometricControl.Data.Entities;
using HydrometricControl.Domain.Interfaces;

namespace HydrometricControl.Domain.Services
{

    public class CondominioService : ICondominioService
    {

        private readonly ApplicationDbContext _contexto;

        public CondominioService(ApplicationDbContext contexto)
            => _contexto = contexto;

        public Task<int> Criar(TbCondominio condominio)
        {
            condominio.DataRegistro = DateTime.Now;
            _contexto.Add(condominio);
            return _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbCondominio>> Listar()
        {
            var lista = await _contexto.Condominio.Where(x => !x.ExclusaoLogica).ToListAsync();
            return lista;
        }

        public async Task<TbCondominio> Buscar(Guid? id)
        {
            return await _contexto.Condominio.FindAsync(id);
        }

        public TbCondominio BuscarPorNome(string nome)
        {
            return _contexto.Condominio.FirstOrDefault(x => string.Equals(x.Nome, nome));
        }

        public Task<int> Alterar(Guid? id, TbCondominio condominio)
        {
            _contexto.Condominio.Update(condominio);
            return _contexto.SaveChangesAsync();
        }


        public Task<int> Excluir(TbCondominio condominio)
        {
            condominio.ExclusaoLogica = true;
            _contexto.Condominio.Update(condominio);
            return _contexto.SaveChangesAsync();
        }

    }

}
