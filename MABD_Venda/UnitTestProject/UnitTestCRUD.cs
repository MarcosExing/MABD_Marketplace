//Este arquivo contém a implantação da classe genérica UnitTestCRUD, pai das classes de testes.

using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace UnitTestProject
{
    /// <summary>
    /// Classe responsável por oferecer a implantação genérica dos testes CRUDS a classes filhas.
    /// </summary>
    public class UnitTestCRUD
    {
        /// <summary>
        /// Método de teste genérico para excluir uma entidade do banco de dados.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório a ser testado.</typeparam>
        /// <typeparam name="TEntity">O tipo de entidade a ser manipulada.</typeparam>
        public void TestDelete<TRepository, TEntity>()
            where TRepository : IRepository<TEntity>, new()
            where TEntity : class, new()
        {
            //Arrange
            IRepository<TEntity> repository = new TRepository();
            List<TEntity> lista = repository.ObterTodos();
            TEntity entidade = lista.Count > 0 ? lista[lista.Count - 1] : default(TEntity);

            //Assert
            if (entidade != null)
            {
                Assert.IsTrue(repository.Excluir(entidade), "A exclusão da entidade do banco de dados falhou!");
            }

            else
            {
                Assert.Fail("A lista ou o banco de dados está vazia(o), não é possível obter a última entidade para excluir.");
            }
        }

        /// <summary>
        /// Método de teste genérico para obter todas as entidades do banco de dados.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório a ser testado.</typeparam>
        /// <typeparam name="TEntity">O tipo de entidade a ser manipulada.</typeparam>
        /// <returns>Uma lista de entidades.</returns>
        public List<TEntity> TestGetAll<TRepository, TEntity>()
            where TRepository : IRepository<TEntity>, new()
            where TEntity : class, new()
        {
            //Arrange
            TRepository repository = new TRepository();
            List<TEntity> lista = repository.ObterTodos();

            //Assert
            Assert.IsTrue(lista.Count > 0, "A lista ou o banco de dados está vazia(o), não é possível obter uma entidade.");

            return lista;
        }

        /// <summary>
        /// Método de teste genérico para obter uma entidade por ID do banco de dados.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório a ser testado.</typeparam>
        /// <typeparam name="TEntity">O tipo de entidade a ser manipulada.</typeparam>
        /// <returns>A entidade encontrada.</returns>
        public TEntity TestGetById<TRepository, TEntity>()
            where TRepository : IRepository<TEntity>, new()
            where TEntity : IEntity, new()
        {
            //Arrange
            TRepository repository = new TRepository();
            TEntity entidade;
            List<TEntity> lista = repository.ObterTodos();

            TEntity entidadeId = lista.Count > 0 ? lista[lista.Count - 1] : default(TEntity);

            //Assert
            if (entidadeId != null)
            {
                entidade = repository.ObterPorId(entidadeId.id);
                Assert.IsNotNull(entidade, "A entidade não deveria ser nula!");

                return entidade;
            }

            else
            {
                Assert.Fail("A lista ou o banco de dados está vazia(o), não é possível obter a última entidade.");
            }

            return default(TEntity);
        }

        /// <summary>
        /// Método de teste genérico para adicionar uma entidade ao banco de dados.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório a ser testado.</typeparam>
        /// <typeparam name="TEntity">O tipo de entidade a ser manipulada.</typeparam>
        /// <param name="entidade">A entidade a ser adicionada.</param>
        public void TestInsert<TRepository, TEntity>(TEntity entidade)
            where TRepository : IRepository<TEntity>, new()
            where TEntity : IEntity, new()
        {
            //Arrange
            TRepository repository = new TRepository();

            //Assert
            Assert.IsTrue(repository.Adicionar(entidade));
        }

        /// <summary>
        /// Método de teste genérico para atualizar uma entidade no banco de dados.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório a ser testado.</typeparam>
        /// <typeparam name="TEntity">O tipo de entidade a ser manipulada.</typeparam>
        /// <param name="entidade">A entidade a ser atualizada.</param>
        public void TestUpdate<TRepository, TEntity>(TEntity entidade)
            where TRepository : IRepository<TEntity>, new()
            where TEntity : IEntity, new()
        {
            //Arrange
            TRepository repository = new TRepository();
            List<TEntity> lista = repository.ObterTodos();
            TEntity entidadeUltima = lista.Count > 0 ? lista[lista.Count - 1] : default(TEntity);

            //Assert
            if (entidadeUltima != null)
            {
                entidade.id = entidadeUltima.id;
                Assert.IsTrue(repository.Atualizar(entidade), "A atualização da entidade no banco de dados falhou!");
            }

            else
            {
                Assert.Fail("A lista ou o banco de dados está vazia(o), não é possível obter a última entidade para atualização.");
            }
        }
    }
}
