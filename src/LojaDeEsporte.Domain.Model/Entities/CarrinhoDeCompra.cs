using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDeEsporte.Domain.Model.Entities
{
    public class CarrinhoDeCompra
    {
        private List<ItemDoCarrinhoDeCompra> _itensDoCarrinhoDeCompras;

        public virtual Guid Id { get; set; }

        public CarrinhoDeCompra()
        {
            _itensDoCarrinhoDeCompras = new List<ItemDoCarrinhoDeCompra>();
        }

        public virtual void AdicionarItem(Produto produto, int quantidade)
        {
            ItemDoCarrinhoDeCompra itemDoCarrinhoDeCompra =
                _itensDoCarrinhoDeCompras.FirstOrDefault(p => p.Produto.Id == produto.Id);

            if (itemDoCarrinhoDeCompra == null)
                _itensDoCarrinhoDeCompras.Add(new ItemDoCarrinhoDeCompra() {Produto = produto, Quantidade = quantidade});
            else
                itemDoCarrinhoDeCompra.Quantidade += quantidade;
        }

        public virtual void RemoverItem(Produto produto)
        {
            _itensDoCarrinhoDeCompras.RemoveAll(i => i.Produto.Id == produto.Id);
        }

        public virtual decimal ValorTotal()
        {
            return _itensDoCarrinhoDeCompras.Sum(i => i.ValorTotal());
        }

        public virtual IEnumerable<ItemDoCarrinhoDeCompra> ItensDoCarrinho
        {
            get { return _itensDoCarrinhoDeCompras; }
            set { _itensDoCarrinhoDeCompras = value.ToList(); }
        }

        public class ItemDoCarrinhoDeCompra
        {
            public virtual Guid Id { get; set; }
            public virtual Produto Produto { get; set; }
            public virtual int Quantidade { get; set; }

            public virtual decimal ValorTotal()
            {
                return Produto.Preco * Quantidade;
            }
        }
    }
}
