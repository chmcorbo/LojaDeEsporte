using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaDeEsporte.Domain.Model.Entities;

namespace LojaDeEsporte.Domain.Model.Repository
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Excluir(Produto produto);
        void Atualizar(Produto produto);

        IQueryable<Produto> Produtos { get; }
    }
}
