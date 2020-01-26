using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class PesquisaViewModel
    {
        public string Pesquisa { get; set; }

        public IList<Produto> Produtos { get; }

        public PesquisaViewModel(IList<Produto> produtos)
        {
            Produtos = produtos;
        }
        public PesquisaViewModel(IList<Produto> produtos, string pesquisa)
        {
            Produtos = produtos;
            Pesquisa = pesquisa;
        }
    }
}