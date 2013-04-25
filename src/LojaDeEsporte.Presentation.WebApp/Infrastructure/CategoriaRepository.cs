using System;
using System.Collections.Generic;
using System.Linq;
using LojaDeEsporte.Domain.Model.Entities;
using LojaDeEsporte.Domain.Model.Repository;

namespace LojaDeEsporte.Presentation.WebApp.Infrastructure
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private static List<Categoria> _categorias;

        public CategoriaRepository()
        {
            _categorias = new List<Categoria>()
                {
                    new Categoria(){ Id = Guid.Parse("{20FA2798-A41C-4172-8D8C-E8D79456884A}"), Nome = "Categoria 1", },
                    new Categoria(){ Id = Guid.Parse("{8B5F08FA-9B48-4394-ACA1-47B5060DFB85}"), Nome = "Categoria 2", }
                };
        }

        public void Adicionar(Categoria categoria)
        {
            categoria.Id = Guid.NewGuid();
            _categorias.Add(categoria);
        }

        public void Excluir(Categoria categoria)
        {
            _categorias.Remove(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            
        }

        public IQueryable<Categoria> Categorias {
            get { return _categorias.AsQueryable(); }
        } 
    }
}