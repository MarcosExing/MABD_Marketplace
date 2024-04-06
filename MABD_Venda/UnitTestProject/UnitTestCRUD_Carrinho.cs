//Este arquivo contém a implementação dos métodos testes CRUD da entidade Carrinho.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por implementar os métodos testes CRUD da entidade Carrinho.
    /// </summary>
    [TestClass]
    public class UnitTestCRUD_Carrinho : IUnitTestCRUD
    {
        [TestMethod]
        public override void TestDelete()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestDelete<CarrinhoRepository, Carrinho>();
        }

        [TestMethod]
        public override void TestGetAll()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetAll<CarrinhoRepository, Carrinho>();
        }

        [TestMethod]
        public override void TestGetById()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetById<CarrinhoRepository, Carrinho>();
        }

        [TestMethod]
        public override void TestInsert()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            ClienteRepository clienteDB = new ClienteRepository();
            ProdutoRepository produtoDB = new ProdutoRepository();

            List<Cliente> listaCliente = clienteDB.ObterTodos();
            Cliente cliente = listaCliente[listaCliente.Count - 1];

            List<Produto> listaProduto = produtoDB.ObterTodos();

            foreach (Produto p in listaProduto)
            {
                p.quantidadePedida = 2;
            }

            Carrinho carrinho = new Carrinho(DateTime.Now, 300, 1, cliente, listaProduto);

            //Assert
            testeCRUD.TestInsert<CarrinhoRepository, Carrinho>(carrinho);
        }

        [TestMethod]
        public override void TestUpdate()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            ProdutoRepository produtoDB = new ProdutoRepository();

            List<Produto> listaProduto = produtoDB.ObterTodos();
            listaProduto.Remove(listaProduto[listaProduto.Count - 1]);

            foreach (Produto p in listaProduto)
            {
                p.quantidadePedida = 1;
            }

            Carrinho carrinho = new Carrinho(DateTime.Now, 100, 0, default, listaProduto);

            //Assert
            testeCRUD.TestUpdate<CarrinhoRepository, Carrinho>(carrinho);
        }
    }
}
