using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;

namespace LojaDeEsporte.Presentation.WebApp.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public CarrinhoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ActionResult Index()
        {
            CarrinhoDeCompra carrinhoDeCompra = RecuperarCarrinho() ?? new CarrinhoDeCompra();

            return View(carrinhoDeCompra);
        }

        [HttpPost]
        public RedirectToRouteResult AdicionarAoCarrinho(Guid Id, string returnUrl)
        {
            Produto produto = _produtoRepository.Produtos.FirstOrDefault(p => p.Id == Id);

            if (produto != null)
                RecuperarCarrinho().AdicionarItem(produto, 1);
 
            return RedirectToAction("Index", "Produto");
        }

        private CarrinhoDeCompra RecuperarCarrinho()
        {
            CarrinhoDeCompra carrinhoDeCompra = (CarrinhoDeCompra)Session["CarrinhoDeCompra"];
            if (carrinhoDeCompra == null) {
                carrinhoDeCompra = new CarrinhoDeCompra();
                Session["CarrinhoDeCompra"] = carrinhoDeCompra;
            }

            return carrinhoDeCompra;
        }


    }
}