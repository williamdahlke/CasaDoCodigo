using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>,IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {

        }

        public IList<Produto> GetLivros()
        {
            return dbset.ToList();
        }

        public void SaveLivros(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!dbset.Where(p => p.Codigo == livro.codigo).Any())
                {                    
                    dbset.Add(new Produto(livro.codigo, livro.nome, livro.preco));
                }                
            }
            _context.SaveChanges();
        }
    }
    public class Livro
    {
        public string codigo { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
    }
}
