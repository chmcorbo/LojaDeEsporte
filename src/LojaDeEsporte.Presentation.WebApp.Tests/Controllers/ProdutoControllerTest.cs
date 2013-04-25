using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaDeEsporte.Presentation.WebApp.Infrastructure;
using NUnit.Framework;
using LojaDeEsporte.Presentation.WebApp.Controllers;
using LojaDeEsporte.Domain.Model.Repository;
using Rhino.Mocks;
using System.Web.Mvc;
using LojaDeEsporte.Domain.Model.Entities;

namespace LojaDeEsporte.Presentation.WebApp.Tests.Controllers
{
    [TestFixture]
    public class ProdutoControllerTest
    {
        IProdutoRepository _repositorio;
        ProdutoController _controller;

        [SetUp]
        public void SetupTests()
        {
            _repositorio = MockRepository.GenerateMock<IProdutoRepository>();
            _controller = new ProdutoController(_repositorio, new CategoriaRepository());
        }

        [Test]
        public void produtocontroller_deve_ser_instanciada()
        {   
            Assert.That(_controller, Is.Not.Null);
        }

        [Test]
        public void metodo_index_deve_retornar_uma_view()
        {
            ActionResult view = _controller.Index();
            Assert.That(view, Is.Not.Null);
        }

        [Test]
        public void metodo_index_deve_retornar_uma_view_com_2_produtos()
        {
            Produto produto1 = new Produto() { Id = Guid.NewGuid(), Nome="Produto1" };
            Produto produto2 = new Produto() { Id = Guid.NewGuid(), Nome = "Produto2" };

            List<Produto> produtos = new List<Produto>() { produto1, produto2 };

            _repositorio = MockRepository.GenerateMock<IProdutoRepository>();
            _repositorio.Expect(a => a.Produtos).Return(produtos.AsQueryable());

            _controller = new ProdutoController(_repositorio, new CategoriaRepository());

            ActionResult view = _controller.Index();

            ViewResult viewResult = (ViewResult)view;
            List<Produto> produtosFromView = ((IEnumerable<Produto>)viewResult.Model).ToList();

            Assert.That(produtosFromView.Count, Is.GreaterThanOrEqualTo(2));
        }
    }
}