//Este arquivo contém a implementação dos métodos testes CRUD da entidade Produto.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por implementar os métodos testes CRUD da entidade Produto.
    /// </summary>
    [TestClass]
    public class UnitTestCRUD_Produto : IUnitTestCRUD
    {
        [TestMethod]
        public override void TestDelete()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestDelete<ProdutoRepository, Produto>();
        }

        [TestMethod]
        public override void TestGetAll()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetAll<ProdutoRepository, Produto>();
        }

        [TestMethod]
        public override void TestGetById()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetById<ProdutoRepository, Produto>();
        }

        [TestMethod]
        public override void TestInsert()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            VendedorRepository vendedorDB = new VendedorRepository();
            CategoriaRepository categoriaDB = new CategoriaRepository();

            List<Vendedor> listaVendedor = listaVendedor = vendedorDB.ObterTodos();
            Vendedor vendedor = listaVendedor[listaVendedor.Count - 1];

            List<Categoria> listaCategoria = categoriaDB.ObterTodos();
            Categoria categoria = listaCategoria[listaCategoria.Count - 1];

            Produto produto = new Produto("Produto legal!", 50, "/caminho_para_uma_imagem", true, vendedor, categoria);

            //Assert
            testeCRUD.TestInsert<ProdutoRepository, Produto>(produto);

        }

        [TestMethod]
        public override void TestUpdate()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            Produto produto = new Produto("Produto diferente!", 60, "/outro_caminho_para_uma_imagem", false, default, default);

            //Assert
            testeCRUD.TestUpdate<ProdutoRepository, Produto>(produto);
        }
    }
}
