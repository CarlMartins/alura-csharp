using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Leilao> BuscarLeiloes();
        IEnumerable<Categoria> BuscarCategorias();
         Leilao BuscarPorId(int id);
         void Incluir(Leilao leilao);
         void Alterar(Leilao leilao);
         void Excluir(Leilao leilao);
    }
}