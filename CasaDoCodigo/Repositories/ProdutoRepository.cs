using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        protected readonly ICategoriaRepository categoriaRepository;

        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            this.categoriaRepository = categoriaRepository;
        }


        public IList<Produto> GetProdutos()
        {
            return dbSet.Include(x => x.Categoria).ToList();
        }

        public async Task<IList<Produto>> GetProdutos(string pesquisa)
        {
            return await dbSet.Include(x => x.Categoria).Where(x => EF.Functions.Like(x.Nome, $"%{pesquisa}%") || EF.Functions.Like(x.Categoria.Nome, $"%{pesquisa}%")).ToListAsync();
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            List<Categoria> categorias = new List<Categoria>();
            foreach (var livro in livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    await categoriaRepository.SaveCategoria(livro.Categoria);

                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoriaRepository.GetCategoria(livro.Categoria)));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
