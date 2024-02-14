﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {

        private readonly ApplicationContext _context;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            this._context = context;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            _context.Database.EnsureCreated();
            List<Livro> livros = GetLivros();

            produtoRepository.SaveLivros(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}

