using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LojaDeEsporte.Domain.Model.Entities;

namespace LojaDeEsporte.Infraestrutura.NHibernate.Mapping
{
    public class CategoriaMapping : ClassMap<Categoria>
    {
        public CategoriaMapping()
        {
            Id(p => p.Id);
            Map(p => p.Nome);
            HasMany(p => p.Produtos).Inverse().Cascade.All();
        }
    }
}