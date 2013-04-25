using System;
using System.Collections.Generic;
using System.Linq;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;

namespace LojaDeEsporte.Presentation.WebApp.Infrastructure
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static List<Produto> _produtos;
        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoRepository()
        {
            _categoriaRepository = new CategoriaRepository();

            _produtos = new List<Produto>
                {
                    new Produto()
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Produto 1",
                            Descricao = "Descrição 1",
                            Categoria = _categoriaRepository.Categorias.FirstOrDefault(),
                            Preco = 100
                        },
                    new Produto()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Produto 2",
                        Descricao = "Descrição 2",
                        Categoria = _categoriaRepository.Categorias.ToList()[1],
                        Preco = 100
                    },
                    new Produto()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Produto 3",
                        Descricao = "Descrição 3",
                        Categoria = _categoriaRepository.Categorias.ToList()[0],
                        Preco = 100
                    },
                    new Produto()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Produto 4",
                        Descricao = "Descrição 4",
                        Categoria = _categoriaRepository.Categorias.ToList()[1],
                        Preco = 100
                    },
                    new Produto()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Produto 5",
                        Descricao = "Descrição 5",
                        Categoria = _categoriaRepository.Categorias.ToList()[0],
                        Preco = 100
                    }
                };
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            _produtos.Add(produto);
        }

        public void Excluir(Produto produto)
        {
            _produtos.Remove(produto);
        }

        public void Atualizar(Produto produto)
        {
            
        }

        public IQueryable<Produto> Produtos
        {
            get { return _produtos.AsQueryable(); }
        }
    }
}