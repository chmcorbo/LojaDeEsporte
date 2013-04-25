using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;

namespace LojaDeEsporte.Presentation.WebApp.Models
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public InformacaoDePaginacao InformacaoDePaginacao { get; set; }
        public string Categoria { get; set; }
    }


    //public class ProdutoViewModel
    //{
    //    private readonly IProdutoRepository _produtoRepository;
    //    private readonly ICategoriaRepository _categoriaRepository;

    //    public ProdutoViewModel(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
    //    {
    //        _produtoRepository = produtoRepository;
    //        _categoriaRepository = categoriaRepository;
    //    }

    //    public IEnumerable<Produto> Todos()
    //    {
    //        return _produtoRepository.Produtos;
    //    }

    //    public IEnumerable<SelectListItem> DropBoxListDeTodasAsCategorias()
    //    {
    //        return _categoriaRepository.Categorias.Select(c => new SelectListItem
    //        {
    //            Value = c.Id.ToString(),
    //            Text = c.Nome
    //        });
    //    }

    //    public void AdicionarProduto(Produto produto, string categoriaId)
    //    {
    //        var categoria = _categoriaRepository.Categorias.FirstOrDefault(c => c.Id == Guid.Parse(categoriaId));

    //        produto.Categoria = categoria;
    //        _produtoRepository.Adicionar(produto);
    //    }
    //}
}