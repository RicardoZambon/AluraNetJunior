using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Categoria> GetCategoria(string nomeCategoria)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Nome == nomeCategoria);
        }

        public async Task SaveCategoria(string nomeCategoria)
        {
            if (!dbSet.Where(p => p.Nome == nomeCategoria).Any())
            {
                await dbSet.AddAsync(new Categoria(nomeCategoria));
            }
            await contexto.SaveChangesAsync();
        }
    }
}