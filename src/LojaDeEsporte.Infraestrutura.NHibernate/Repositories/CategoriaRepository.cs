using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;
using LojaDeEsporte.Infraestrutura.NHibernate.Builders;
using NHibernate;

namespace LojaDeEsporte.Infraestrutura.NHibernate.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
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

        public void Adicionar(Categoria categoria)
        {
            Atualizar(categoria);
        }

        public void Excluir(Categoria categoria)
        {
            ITransaction transaction = Session.BeginTransaction();
            Session.Delete(categoria);
            transaction.Commit();
            transaction.Dispose();
        }

        public void Atualizar(Categoria categoria)
        {
            ITransaction transaction = Session.BeginTransaction();
            Session.SaveOrUpdate(categoria);
            transaction.Commit();
            transaction.Dispose();
        }

        public IQueryable<Categoria> Categorias
        {
            get { return Session.CreateCriteria(typeof(Categoria)).List<Categoria>().AsQueryable(); }
        }
    }
}