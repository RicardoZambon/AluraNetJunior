using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string nomeCategorias);
        Task<Categoria> GetCategoria(string nomeCategoria);
    }
}