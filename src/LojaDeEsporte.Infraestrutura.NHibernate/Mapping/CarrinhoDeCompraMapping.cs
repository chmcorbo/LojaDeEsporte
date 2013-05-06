using FluentNHibernate.Mapping;
using LojaDeEsporte.Domain.Model.Entities;

namespace LojaDeEsporte.Infraestrutura.NHibernate.Mapping
{
    public class CarrinhoDeCompraMapping : ClassMap<CarrinhoDeCompra>
    {
        public CarrinhoDeCompraMapping()
        {
            Id(c => c.Id);
            HasMany(c => c.ItensDoCarrinho).Cascade.All();
        }
    }

    public class ItemDoCarrinhoDeCompraMapping : ClassMap<CarrinhoDeCompra.ItemDoCarrinhoDeCompra>
    {
        public ItemDoCarrinhoDeCompraMapping()
        {
            Id(i => i.Id);
            References(c => c.Produto);
            Map(i => i.Quantidade);
        }
    }
}