//Este arquivo contém a implementação dos métodos testes CRUD da entidade Categoria.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por implementar os métodos testes CRUD da entidade Categoria.
    /// </summary>
    [TestClass]
    public class UnitTestCRUD_Categoria : IUnitTestCRUD
    {
        [TestMethod]
        public override void TestDelete()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestDelete<CategoriaRepository, Categoria>();
        }

        [TestMethod]
        public override void TestGetAll()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetAll<CategoriaRepository, Categoria>();
        }

        [TestMethod]
        public override void TestGetById()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();

            //Assert
            testeCRUD.TestGetById<CategoriaRepository, Categoria>();
        }

        [TestMethod]
        public override void TestInsert()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            Categoria categoria = new Categoria("Celular");

            //Assert
            testeCRUD.TestInsert<CategoriaRepository, Categoria>(categoria);
        }

        [TestMethod]
        public override void TestUpdate()
        {
            //Arrange
            UnitTestCRUD testeCRUD = new UnitTestCRUD();
            Categoria categoria = new Categoria("Moveis");

            //Assert
            testeCRUD.TestUpdate<CategoriaRepository, Categoria>(categoria);
        }
    }
}
