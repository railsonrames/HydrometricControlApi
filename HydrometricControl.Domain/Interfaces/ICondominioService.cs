using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HydrometricControl.Data.Entities;

namespace HydrometricControl.Domain.Interfaces
{

    public interface ICondominioService
    {

        Task<TbCondominio> Buscar(Guid? id);
        TbCondominio BuscarPorNome(string nome);
        Task<IEnumerable<TbCondominio>> Listar();
        Task<int> Criar(TbCondominio condominio);
        Task<int> Excluir(TbCondominio condominio);
        Task<int> Alterar(Guid? id, TbCondominio condominio);

    }

}
