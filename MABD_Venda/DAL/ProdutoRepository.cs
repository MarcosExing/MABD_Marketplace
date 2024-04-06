// Este arquivo contém a implementação da classe ProdutoRepository, que é responsável pela manipulação dos dados da tabela tblPRODUTO no banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável pelas operações CRUD da tabela tblPRODUTO no banco de dados.
    /// </summary>
    public class ProdutoRepository : IRepository<Produto>
    {
        /// <summary>
        /// Adiciona um novo produto ao banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Produto a ser adicionado.</param>
        /// <returns>True se a adição for bem-sucedida, False caso contrário.</returns>
        public bool Adicionar(Produto entidade)
        {
            string query = "INSERT INTO tblPRODUTO(DESCRICAO, PRECO, IMAGEM, STATUS, VENDEDOR_ID, CATEGORIA_ID) " +
                "VALUES(@Descricao, @Preco, @Imagem, @Status, @Vendedor_id, @Categoria_id)";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Descricao", entidade.descricao);
            cmd.Parameters.AddWithValue("@Preco", entidade.preco);
            cmd.Parameters.AddWithValue("@Imagem", entidade.imagem);
            cmd.Parameters.AddWithValue("@Status", entidade.status);
            cmd.Parameters.AddWithValue("@Vendedor_id", entidade.vendedor.id);
            cmd.Parameters.AddWithValue("@Categoria_id", entidade.categoria.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Atualiza um objeto Produto no banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Produto a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>
        public bool Atualizar(Produto entidade)
        {
            string query = "UPDATE tblPRODUTO SET " +
                "DESCRICAO = @Descricao, " +
                "PRECO = @Preco, " +
                "IMAGEM = @Imagem, " +
                "STATUS = @Status " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Descricao", entidade.descricao);
            cmd.Parameters.AddWithValue("@Preco", entidade.preco);
            cmd.Parameters.AddWithValue("@Imagem", entidade.imagem);
            cmd.Parameters.AddWithValue("@Status", entidade.status);
            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Exclui um produto do banco de dados, incluindo a remoção de seus registros associados nos Carrinhos.
        /// </summary>
        /// <param name="entidade">O objeto Produto a ser excluído.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public bool Excluir(Produto entidade)
        {
            ExcluirProdutosItemCarrinho(entidade.id);

            string query = "DELETE FROM tblPRODUTO " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Obtém um objeto Produto do banco de dados com base no ID.
        /// </summary>
        /// <param name="id">O ID do Produto a ser obtido.</param>
        /// <returns>O objeto Produto correspondente ao ID fornecido, ou um novo objeto Produto se não encontrado.</returns>
        public Produto ObterPorId(int id)
        {
            string query = "SELECT * FROM tblPRODUTO " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", id);

            Produto produto = new Produto();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    produto.id = Convert.ToInt32(reader["ID"]);
                    produto.descricao = reader["DESCRICAO"].ToString();
                    produto.preco = Convert.ToDecimal((reader["PRECO"]));
                    produto.imagem = reader["IMAGEM"].ToString();
                    produto.status = Convert.ToBoolean(reader["STATUS"]);
                    produto.categoria = new Categoria();
                    produto.categoria.id = Convert.ToInt32(reader["CATEGORIA_ID"]);
                    produto.vendedor = new Vendedor();
                    produto.vendedor.id = Convert.ToInt32(reader["VENDEDOR_ID"]);

                    CategoriaRepository categoriaDB = new CategoriaRepository();
                    Categoria categoria = categoriaDB.ObterPorId(produto.categoria.id);
                    produto.categoria = categoria;

                    VendedorRepository vendedorDB = new VendedorRepository();
                    Vendedor vendedor = vendedorDB.ObterPorId(produto.vendedor.id);
                    produto.vendedor = vendedor;
                }

                ConexaoBD.Fechar();
            }

            return produto != null ? produto : new Produto(); //throw new Exception("Não foi possível encontrar nenhum produto!");
        }

        /// <summary>
        /// Obtém uma lista de todos os produtos no banco de dados.
        /// </summary>
        /// <returns>Uma lista de objetos Produto, ou uma lista vazia se nenhum registro for encontrado.</returns>
        public List<Produto> ObterTodos()
        {
            string query = "SELECT * FROM tblPRODUTO";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            List<Produto> listaProduto = new List<Produto>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produto produto = new Produto();

                    produto.id = Convert.ToInt32(reader["ID"]);
                    produto.descricao = reader["DESCRICAO"].ToString();
                    produto.preco = Convert.ToDecimal((reader["PRECO"]));
                    produto.imagem = reader["IMAGEM"].ToString();
                    produto.status = Convert.ToBoolean(reader["STATUS"]);
                    produto.categoria = new Categoria();
                    produto.categoria.id = Convert.ToInt32(reader["CATEGORIA_ID"]);
                    produto.vendedor = new Vendedor();
                    produto.vendedor.id = Convert.ToInt32(reader["VENDEDOR_ID"]);

                    CategoriaRepository categoriaDB = new CategoriaRepository();
                    Categoria categoria = categoriaDB.ObterPorId(produto.categoria.id);
                    produto.categoria = categoria;

                    VendedorRepository vendedorDB = new VendedorRepository();
                    Vendedor vendedor = vendedorDB.ObterPorId(produto.vendedor.id);
                    produto.vendedor = vendedor;

                    listaProduto.Add(produto);
                }

                ConexaoBD.Fechar();
            }

            return listaProduto.Count > 0 ? listaProduto : new List<Produto>(); //throw new Exception("Não foi possível achar nenhum produto!");
        }

        /// <summary>
        /// Exclui um produto associado a um item do carrinho no banco de dados.
        /// </summary>
        /// <param name="produtoID">O ID do produto a ser excluído do item do carrinho.</param>
        public void ExcluirProdutosItemCarrinho(int produtoID)
        {
            string query = "DELETE FROM tblITEM_CARRINHO " +
                           "WHERE PRODUTO_ID = @Produto_id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Produto_id", produtoID);

            ConexaoBD.Fechar();
        }

        /// <summary>
        /// Obtém o ID do último Produto adicionado ao banco de dados.
        /// </summary>
        /// <returns>O ID do último Produto adicionado.</returns>
        public int ObterUltimoId()
        {
            return SupportSqlConnection.ObterUltimoId("tblPRODUTO");
        }
    }
}
