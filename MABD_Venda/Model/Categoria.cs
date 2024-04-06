// Este arquivo contém a classe Categoria, que representa uma entidade de categoria no sistema.

namespace Model
{
    /// <summary>
    /// Classe responsável por implementar a entidade Categoria que sera usada pela classe Produto.
    /// </summary>
    public class Categoria : IEntity
    {
        public int id { get; set; }
        public string nome { get; set; }

        public Categoria(string nome)
        {
            this.nome = nome;
        }

        public Categoria() { }
    }
}
