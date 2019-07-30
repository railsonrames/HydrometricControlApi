using HydrometricControl.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrometricControl.Domain.Interfaces
{

    public interface ILeituraGeralService
    {

        Task<IEnumerable<TbLeituraGeral>> Listar(Guid? id);
        Task<int> Criar(TbLeituraGeral leituraGeral);
        Task<TbLeituraGeral> Buscar(Guid? id);
        Task<int> Editar(TbLeituraGeral leituraGeral);
        Task<int> Excluir(TbLeituraGeral tbLeituraGeral);

    }

}
