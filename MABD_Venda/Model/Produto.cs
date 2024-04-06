// Este arquivo contém a implementação da classe Produto, que representa os produtos do marketplace.

namespace Model
{
    /// <summary>
    /// Classe responsável por implementar a entidade Produto.
    /// </summary>
    public class Produto : IEntity
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public string imagem { get; set; }
        public bool status { get; set; }
        public decimal quantidadePedida { get; set; }
        public Vendedor vendedor { get; set; }
        public Categoria categoria { get; set; }

        public Produto(string descricao, decimal preco, string imagem, bool status, Vendedor vendedor, Categoria categoria)
        {
            this.descricao = descricao;
            this.preco = preco;
            this.imagem = imagem;
            this.status = status;
            this.vendedor = vendedor;
            this.categoria = categoria;
        }

        public Produto() { }
    }
}
