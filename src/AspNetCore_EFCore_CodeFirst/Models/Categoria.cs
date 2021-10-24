using System.Collections.Generic;

namespace AspNetCore_EFCore_CodeFirst.Models
{
    public class Categoria
    {

        public int ID { get; set; }
        public string Nome { get; set; }

        public ICollection<Livro> Livros { get; set; }

        public Categoria()
        {

        }
        
        public Categoria(int iD, string nome)
        {
            ID = iD;
            Nome = nome;
        }

       
    }
}