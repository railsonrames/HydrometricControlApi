using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HydrometricControl.Data.Models;
using HydrometricControl.Data.Entities;

namespace HydrometricControl.Domain.Interfaces
{

    public interface ILeituraService
    {

        Task<TbLeitura> Buscar(Guid? id);
        Task<int> Criar(TbLeitura leitura);
        Task<int> Excluir(TbLeitura leitura);
        Task<IEnumerable<TbLeitura>> Listar();
        Task<IEnumerable<TbLeitura>> ListaFiltrada(FiltroLeituraData filtro);
        Task<IEnumerable<TbLeitura>> ListarInicial();
        Task<int> Alterar(Guid? id, TbLeitura leitura);
        Task<int> SalvarListaLeituras(List<TbLeitura> leituras);

    }

}
