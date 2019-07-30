using HydrometricControl.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrometricControl.Domain.Interfaces
{

    public interface IFaixaService
    {

        Task<TbFaixa> Buscar(Guid? id);
        Task<int> Criar(TbFaixa faixa);
        Task<int> Excluir(TbFaixa faixa);
        Task<IEnumerable<TbFaixa>> Listar();
        Task<int> Alterar(Guid? id, TbFaixa faixa);

    }

}
