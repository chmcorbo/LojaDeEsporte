using System;
using System.Collections.Generic;

namespace LojaDeEsporte.Domain.Model.Entities
{
    public class Categoria
    {
        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}