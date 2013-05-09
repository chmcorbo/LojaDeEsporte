using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;
using LojaDeEsporte.Presentation.WebApp.Models;

namespace LojaDeEsporte.Presentation.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        readonly IProdutoRepository _repositorio;
        readonly ICategoriaRepository _repositorioCategoria;

        public int TamanhoDaPagina = 4;

        public ProdutoController(IProdutoRepository repositorio, ICategoriaRepository categoriaRepository)
        {
            _repositorio = repositorio;
            _repositorioCategoria = categoriaRepository;
        }

        //
        // GET: /Produto/
        public ActionResult Index(string categoria, int pagina = 1)
        {
            IEnumerable<Produto> produtos;

            if (string.IsNullOrEmpty(categoria))
                produtos = _repositorio.Produtos
                                       .OrderBy(p => p.Nome)
                                       .Skip((pagina - 1)*TamanhoDaPagina)
                                       .Take(TamanhoDaPagina);
            else
                produtos = _repositorio.Produtos
                                       .Where(p => p.Categoria == null || p.Categoria.Nome == categoria)
                                       .OrderBy(p => p.Nome)
                                       .Skip((pagina - 1)*TamanhoDaPagina)
                                       .Take(TamanhoDaPagina);


            ProdutoViewModel produtoViewModel = new ProdutoViewModel()
                {
                    Produtos = produtos,
                    InformacaoDePaginacao = new InformacaoDePaginacao()
                        {
                            PaginaAtual = pagina, 
                            ItensPorPagina = TamanhoDaPagina,
                            TotalDeItems = categoria == null ? 
                                _repositorio.Produtos.Count() : 
                                _repositorio.Produtos.Count(p => p.Categoria.Nome == categoria)
                        },
                    Categoria = categoria
                };

            return View(produtoViewModel);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            IEnumerable<SelectListItem> items = _repositorioCategoria.Categorias.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            });

            ViewBag.Categorias = items;
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            string categoriaId = Request.Form["Categorias"];
            Categoria categoria = _repositorioCategoria.Categorias.FirstOrDefault(c => c.Id == Guid.Parse(categoriaId));

            produto.Categoria = categoria;
            _repositorio.Adicionar(produto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(Guid Id)
        {
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.Id == Id);
            return View(produto);
        }
    }
}