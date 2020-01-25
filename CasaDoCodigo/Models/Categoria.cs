using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Categoria : BaseModel
    {
        [Required]
        public string Nome { get; set; }

        public Categoria()
        {

        }
        public Categoria(string nome)
        {
            this.Nome = nome;
        }
    }
}