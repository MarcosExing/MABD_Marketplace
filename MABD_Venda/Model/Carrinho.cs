// Este arquivo contém a classe Carrinho, que representa um carrinho de compras e suas propriedades associadas.

using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Classe responsável por implementar a entidade Carrinho, que representa um carrinho de compras e suas características.
    /// </summary>
    public class Carrinho : IEntity
    {
        public int id { get; set; }
        public DateTime dataPedido { get; set; }
        public decimal valorTotal { get; set; }
        public int statusPedido { get; set; }
        public Cliente cliente { get; set; }
        public List<Produto> produtos { get; set; }

        public Carrinho(DateTime dataPedido, decimal valorTotal, int statusPedido, Cliente cliente, List<Produto> produtos)
        {
            this.dataPedido = dataPedido;
            this.valorTotal = valorTotal;
            this.statusPedido = statusPedido;
            this.cliente = cliente;
            this.produtos = produtos;
        }

        public Carrinho() { }
    }
}
