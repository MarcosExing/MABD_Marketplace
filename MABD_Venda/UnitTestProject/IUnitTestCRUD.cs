//Este arquivo contém a implantação da interface IUnitTestCRUD, responsável por oferecer a estrutura de testes CRUD.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Interface responsável por oferecer a estrutura de testes CRUD.
    /// </summary>
    [TestClass]
    public abstract class IUnitTestCRUD
    {
        [TestMethod]
        public abstract void TestInsert();

        [TestMethod]
        public abstract void TestUpdate();

        [TestMethod]
        public abstract void TestDelete();

        [TestMethod]
        public abstract void TestGetById();

        [TestMethod]
        public abstract void TestGetAll();
    }
}
