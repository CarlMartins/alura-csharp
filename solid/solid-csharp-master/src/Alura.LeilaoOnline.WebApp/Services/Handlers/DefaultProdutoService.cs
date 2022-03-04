using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
        private readonly ILeilaoDao _dao;
        private readonly ICategoriaDao _categoriaDao;

        public DefaultProdutoService(ILeilaoDao dao, ICategoriaDao categoriaDao)
        {
            _dao = dao;
            _categoriaDao = categoriaDao;
        }
        
        public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();
            return _dao.BuscarLeiloes()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao()
        {
            return _categoriaDao.ConsultaCategorias()
                .Select(c => new CategoriaComInfoLeilao()
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Rascunho),
                    EmPregao = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Pregao),
                    Finalizados = c.Leiloes.Count(l => l.Situacao == SituacaoLeilao.Finalizado)

                });
        }

        public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id)
        {
            return _categoriaDao.ConsultaCategoriaPorId(id);
        }
    }
}