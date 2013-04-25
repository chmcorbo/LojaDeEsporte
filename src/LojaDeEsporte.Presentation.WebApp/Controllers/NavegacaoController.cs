using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeEsporte.Domain.Model.Repository;

namespace LojaDeEsporte.Presentation.WebApp.Controllers
{
    public class NavegacaoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public NavegacaoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //
        // GET: /Navegacao/

        public PartialViewResult Menu()
        {
            IEnumerable<string> categorias =
                _produtoRepository.Produtos.Select(p => p.Categoria.Nome).Distinct().OrderBy(p => p);

            return PartialView(categorias);
        }
    }
}