using System;

namespace LojaDeEsporte.Domain.Model.Entities
{
    public class Produto
    {
        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual decimal Preco { get; set; }
    }
}