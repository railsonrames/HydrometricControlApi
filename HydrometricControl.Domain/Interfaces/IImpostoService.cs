using HydrometricControl.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrometricControl.Domain.Interfaces
{

    public interface IImpostoService
    {

        Task<TbImposto> Buscar(Guid? id);
        Task<IEnumerable<TbImposto>> Listar();
        Task<int> Criar(TbImposto imposto);
        Task<int> Excluir(TbImposto imposto);
        Task<int> Alterar(Guid? id, TbImposto imposto);

    }

}
