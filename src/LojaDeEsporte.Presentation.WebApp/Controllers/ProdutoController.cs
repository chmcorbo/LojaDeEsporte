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

        public ActionResult Index(int pagina = 1)
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel()
                {
                    Produtos = _repositorio.Produtos
                                            .OrderBy(p => p.Nome)
                                            .Skip((pagina - 1) * TamanhoDaPagina)
                                            .Take(TamanhoDaPagina),

                    InformacaoDePaginacao = new InformacaoDePaginacao()
                        {
                            PaginaAtual = pagina, 
                            ItensPorPagina = TamanhoDaPagina, 
                            TotalDeItems = _repositorio.Produtos.Count()
                        }
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
    }
}