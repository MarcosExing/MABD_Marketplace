//Este arquivo contém a implementação dos métodos de testes CRUD para a entidade Endereco.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por implementar os métodos de testes CRUD para a entidade Endereco.
    /// </summary>
    [TestClass]
    public class UnitTestCRUD_Endereco : IUnitTestCRUD
    {
        [TestMethod]
        public override void TestDelete()
        {
            var testeCRUD = new UnitTestCRUD();

            testeCRUD.TestDelete<EnderecoRepository, Endereco>();
        }

        [TestMethod]
        public override void TestGetAll()
        {
            var testeCRUD = new UnitTestCRUD();

            testeCRUD.TestGetAll<EnderecoRepository, Endereco>();
        }

        [TestMethod]
        public override void TestGetById()
        {
            var testeCRUD = new UnitTestCRUD();

            testeCRUD.TestGetById<EnderecoRepository, Endereco>();
        }

        [TestMethod]
        public override void TestInsert()
        {
            Endereco endereco = new Endereco("14080119", "Cidade", "Estado", "Rua", "Bairro");
            var testeCRUD = new UnitTestCRUD();

            testeCRUD.TestInsert<EnderecoRepository, Endereco>(endereco);

        }

        [TestMethod]
        public override void TestUpdate()
        {
            Endereco endereco = new Endereco("18213140", "Itapetininga", "SP", "Rua José Fonseca Diniz", "Vila Leonor");
            var testeCRUD = new UnitTestCRUD();

            testeCRUD.TestUpdate<EnderecoRepository, Endereco>(endereco);
        }
    }
}
