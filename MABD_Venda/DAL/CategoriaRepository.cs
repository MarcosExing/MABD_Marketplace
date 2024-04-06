// Este arquivo contém a implementação da classe CategoriaRepository, que é responsável pela manipulação dos dados da tabela tblCATEGORIA no banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável pelas operações CRUD da tabela tblCATEGORIA no banco de dados.
    /// </summary>
    public class CategoriaRepository : IRepository<Categoria>
    {
        /// <summary>
        /// Adiciona uma nova categoria ao banco de dados.
        /// </summary>
        /// <param name="entidade">A categoria a ser adicionada.</param>
        /// <returns>True se a adição for bem-sucedida, False caso contrário.</returns>
        public bool Adicionar(Categoria entidade)
        {
            string query = "INSERT INTO tblCATEGORIA(NOME) " +
                "VALUES(@Nome)";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Nome", entidade.nome);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Atualiza um objeto Categoria no banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Categoria a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>
        public bool Atualizar(Categoria entidade)
        {
            string query = "UPDATE tblCATEGORIA SET " +
                "NOME = @Nome " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Nome", entidade.nome);
            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Exclui uma categoria do banco de dados, incluindo a exclusão de todos os produtos associados.
        /// </summary>
        /// <param name="entidade">A categoria a ser excluída.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public bool Excluir(Categoria entidade)
        {
            ExcluirProdutos(entidade.id);

            string query = "DELETE FROM tblCATEGORIA " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Obtém uma categoria do banco de dados com base no seu ID.
        /// </summary>
        /// <param name="id">O ID da categoria a ser obtida.</param>
        /// <returns>Um objeto Categoria se encontrado, ou um novo objeto Categoria se não existir.</returns>
        public Categoria ObterPorId(int id)
        {
            string query = "SELECT * FROM tblCATEGORIA " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", id);

            Categoria categoria = new Categoria();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    categoria.id = Convert.ToInt32(reader["ID"]);
                    categoria.nome = reader["Nome"].ToString();
                }

                ConexaoBD.Fechar();
            }

            return categoria != null ? categoria : new Categoria(); //throw new Exception("Não foi possível encontrar nenhuma categoria");
        }

        /// <summary>
        /// Obtém uma lista de todas as categorias do banco de dados.
        /// </summary>
        /// <returns>Uma lista de objetos Categoria, ou uma lista vazia se não houver categorias.</returns>
        public List<Categoria> ObterTodos()
        {
            string query = "SELECT * FROM tblCATEGORIA";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            List<Categoria> listaCategoria = new List<Categoria>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.id = Convert.ToInt32(reader["ID"]);
                    categoria.nome = reader["Nome"].ToString();

                    listaCategoria.Add(categoria);
                }

                ConexaoBD.Fechar();
            }

            return listaCategoria.Count > 0 ? listaCategoria : new List<Categoria>(); //throw new Exception("Não foi possível encontrar nenhuma categoria");
        }

        /// <summary>
        /// Exclui produtos associados a uma categoria no banco de dados.
        /// </summary>
        /// <param name="categoriaID">O ID da categoria cujos produtos serão excluídos.</param>
        private void ExcluirProdutos(int categoriaID)
        {
            ProdutoRepository produtoDB = new ProdutoRepository();

            List<Produto> listaProdutos = SupportSqlConnection.ObterDependentes<ProdutoRepository, Produto>(categoriaID, "SELECT ID FROM tblPRODUTO WHERE CATEGORIA_ID = @Categoria_id", "@Categoria_id");
            if (listaProdutos.Count > 0)
            {
                foreach (Produto p in listaProdutos)
                {
                    produtoDB.Excluir(p);
                }
            }
        }

        /// <summary>
        /// Obtém o ID do último Categoria adicionado ao banco de dados.
        /// </summary>
        /// <returns>O ID do último Categoria adicionado.</returns>
        public int ObterUltimoId()
        {
            return SupportSqlConnection.ObterUltimoId("tblCATEGORIA");
        }
    }
}
