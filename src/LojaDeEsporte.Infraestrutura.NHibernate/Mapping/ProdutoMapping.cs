using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LojaDeEsporte.Domain.Model.Entities;

namespace LojaDeEsporte.Infraestrutura.NHibernate.Mapping
{
    public class ProdutoMapping : ClassMap<Produto>
    {
        public ProdutoMapping()
        {
            Id(p => p.Id);
            Map(p => p.Nome);
            Map(p => p.Descricao);
            Map(p => p.Preco);
            References(p => p.Categoria);
        }
    }
}