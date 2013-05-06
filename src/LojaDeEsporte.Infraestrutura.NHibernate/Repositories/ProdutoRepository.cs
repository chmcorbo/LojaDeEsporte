using System;
using System.Linq;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;
using LojaDeEsporte.Infraestrutura.NHibernate.Builders;
using NHibernate;

namespace LojaDeEsporte.Infraestrutura.NHibernate.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        HybridSessionBuilder _builder = new HybridSessionBuilder();

        private ISession _session;
        public virtual ISession Session
        {
            get
            {
                if (_builder == null)
                    _builder = new HybridSessionBuilder();

                return _session ?? (_session = _builder.GetSession());
            }
        }

        public ProdutoRepository()
        {
            
        }

        public void Adicionar(Produto produto)
        {
            Atualizar(produto);
        }

        public void Excluir(Produto produto)
        {
            ITransaction transaction = Session.BeginTransaction();
            Session.Delete(produto);
            transaction.Commit();
            transaction.Dispose();
        }

        public void Atualizar(Produto produto)
        {
            ITransaction transaction = Session.BeginTransaction();
            Session.SaveOrUpdate(produto);
            transaction.Commit();
            transaction.Dispose();
        }

        public IQueryable<Produto> Produtos {
            get { return Session.CreateCriteria(typeof(Produto)).List<Produto>().AsQueryable(); }
        }
    }
}