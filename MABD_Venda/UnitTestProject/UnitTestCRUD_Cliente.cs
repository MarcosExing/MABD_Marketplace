//Este arquivo contém a implantação dos métodos testes CRUD da entidade Cliente.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por implementar os métodos testes CRUD para a entidade Cliente.
    /// </summary>
    [TestClass]
    public class UnitTestCRUD_Cliente : IUnitTestCRUD
    {
        [TestMethod]
        public override void TestDelete()
        {

            //Arrange
            var testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestDelete<ClienteRepository, Cliente>();
        }

        [TestMethod]
        public override void TestGetAll()
        {
            //Arrange
            var testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetAll<ClienteRepository, Cliente>();
        }

        [TestMethod]
        public override void TestGetById()
        {
            //Arrange
            var testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetById<ClienteRepository, Cliente>();
        }

        [TestMethod]
        public override void TestInsert()
        {
            //Arrange
            var testeCRUD = new UnitTestCRUD();
            List<Endereco> listaEndereco = testeCRUD.TestGetAll<EnderecoRepository, Endereco>();
            Endereco endereco = listaEndereco[listaEndereco.Count - 1];
            Cliente cliente = new Cliente("leticia@gmail.com", "Leticia12345", endereco, "Leticia", 93981365704);

            //Assert
            testeCRUD.TestInsert<ClienteRepository, Cliente>(cliente);
        }

        [TestMethod]
        public override void TestUpdate()
        {
            //Arrange
            var testeCRUD = new UnitTestCRUD();
            Cliente cliente = new Cliente("leticiaCarvalho@gmail.com", "Leticia2004", default, "Leticia Carvalho", 41659969476);

            //Assert
            testeCRUD.TestUpdate<ClienteRepository, Cliente>(cliente);
        }
    }
}
