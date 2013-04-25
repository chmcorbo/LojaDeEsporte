using System.Linq;
using LojaDeEsporte.Domain.Model.Entities;

namespace LojaDeEsporte.Domain.Model.Repository
{
    public interface ICategoriaRepository
    {
        void Adicionar(Categoria categoria);
        void Excluir(Categoria categoria);
        void Atualizar(Categoria categoria);

        IQueryable<Categoria> Categorias { get; }
    }
}