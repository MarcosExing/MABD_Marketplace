//Este arquivo contém a implementação da dos métodos testes CRUD da entidade Vendedor.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por implementar os métodos testes CRUD da entidade Vendedor.
    /// </summary>
    [TestClass]
    public class UnitTestCRUD_Vendedor : IUnitTestCRUD
    {
        [TestMethod]
        public override void TestDelete()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestDelete<VendedorRepository, Vendedor>();
        }

        [TestMethod]
        public override void TestGetAll()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetAll<VendedorRepository, Vendedor>();
        }

        [TestMethod]
        public override void TestGetById()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetById<VendedorRepository, Vendedor>();
        }

        [TestMethod]
        public override void TestInsert()
        {
            //Arrange
            var testeCRUD = new UnitTestCRUD();
            List<Endereco> listaEndereco = testeCRUD.TestGetAll<EnderecoRepository, Endereco>();
            Endereco endereco = listaEndereco[listaEndereco.Count - 1];
            Vendedor vendedor = new Vendedor("Gabriz@gmail.com", "Gabriz5648421", endereco, "Gabrig Rezende Esportes ME", "Esportes Gabrig", "02482746000104", 16);

            //Assert
            testeCRUD.TestInsert<VendedorRepository, Vendedor>(vendedor);
        }

        [TestMethod]
        public override void TestUpdate()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            Vendedor vendedor = new Vendedor("Peixoto@gmail.com", "Peixoto5648421", default, "Gabrig Rezende Esportes ME", "Esportes Peixoto", "02482746000104", 17);

            //Assert
            testeCRUD.TestUpdate<VendedorRepository, Vendedor>(vendedor);
        }
    }
}
