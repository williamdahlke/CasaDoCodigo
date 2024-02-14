using CasaDoCodigo.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveLivros(List<Livro> livros);
        IList<Produto>GetLivros();
    }
}