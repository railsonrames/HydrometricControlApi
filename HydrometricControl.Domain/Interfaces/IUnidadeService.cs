using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HydrometricControl.Data.Entities;

namespace HydrometricControl.Domain.Interfaces
{

    public interface IUnidadeService
    {

        TbUnidade BuscarBeta(Guid id);
        Task<TbUnidade> Buscar(Guid? id);
        Task<int> Criar(TbUnidade unidade);
        void CriarSincrono(TbUnidade unidade);
        Task<int> Excluir(TbUnidade unidade);
        Task<IEnumerable<TbUnidade>> Listar();
        Task<int> Alterar(Guid? id, TbUnidade unidade);
        Task<IEnumerable<TbUnidade>> ListarPorCondominio(Guid idCondominio);

    }

}
