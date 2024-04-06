// Este arquivo contém a implementação da classe VendedorRepository, que é responsável pela manipulação dos dados da tabela tblVENDEDOR no banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável pelas operações CRUD da tabela tblVENDEDOR no banco de dados.
    /// </summary>
    public class VendedorRepository : IRepository<Vendedor>
    {
        /// <summary>
        /// Adiciona um novo Vendedor ao banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Vendedor a ser adicionado.</param>
        /// <returns>True se a adição for bem-sucedida, False caso contrário.</returns>
        public bool Adicionar(Vendedor entidade)
        {
            string query = "INSERT INTO tblVENDEDOR(RAZAO_SOCIAL, NOME_FANTASIA, EMAIL, SENHA, CNPJ, COMISSAO, ENDERECO_ID) " +
                "VALUES (@RazaoSocial, @NomeFantasia, @Email, @Senha, @Cnpj, @Comissao, @EnderecoId)";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@RazaoSocial", entidade.razaoSocial);
            cmd.Parameters.AddWithValue("@NomeFantasia", entidade.nomeFantasia);
            cmd.Parameters.AddWithValue("@Email", entidade.email);
            cmd.Parameters.AddWithValue("@Senha", entidade.senha);
            cmd.Parameters.AddWithValue("Cnpj", entidade.cnpj);
            cmd.Parameters.AddWithValue("@Comissao", entidade.comissao);
            cmd.Parameters.AddWithValue("@EnderecoId", entidade.endereco.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Atualiza as informações de um Vendedor no banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Vendedor a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>
        public bool Atualizar(Vendedor entidade)
        {
            string query = "UPDATE tblVENDEDOR SET " +
                "RAZAO_SOCIAL = @RazaoSocial, " +
                "NOME_FANTASIA = @NomeFantasia, " +
                "EMAIL = @Email, " +
                "SENHA = @Senha, " +
                "CNPJ = @Cnpj, " +
                "COMISSAO = @Comissao " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@RazaoSocial", entidade.razaoSocial);
            cmd.Parameters.AddWithValue("@NomeFantasia", entidade.nomeFantasia);
            cmd.Parameters.AddWithValue("@Email", entidade.email);
            cmd.Parameters.AddWithValue("@Senha", entidade.senha);
            cmd.Parameters.AddWithValue("@Cnpj", entidade.cnpj);
            cmd.Parameters.AddWithValue("@Comissao", entidade.comissao);

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Remove um vendedor do banco de dados, incluindo a exclusão dos produtos associados.
        /// </summary>
        /// <param name="entidade">O objeto Vendedor a ser removido.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public bool Excluir(Vendedor entidade)
        {
            ExcluirProdutos(entidade.id);

            string query = "DELETE FROM tblVENDEDOR " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Obtém um objeto Vendedor do banco de dados com base no ID.
        /// </summary>
        /// <param name="id">O ID do Vendedor a ser obtido.</param>
        /// <returns>O objeto Vendedor se encontrado, um novo objeto Vendedor vazio caso contrário.</returns>
        public Vendedor ObterPorId(int id)
        {
            string query = "SELECT * FROM tblVENDEDOR " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("Id", id);

            Vendedor vendedor = new Vendedor();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    vendedor.id = Convert.ToInt32(reader["ID"]);
                    vendedor.razaoSocial = reader["RAZAO_SOCIAL"].ToString();
                    vendedor.nomeFantasia = reader["NOME_FANTASIA"].ToString();
                    vendedor.email = reader["EMAIL"].ToString();
                    vendedor.senha = reader["SENHA"].ToString();
                    vendedor.cnpj = reader["CNPJ"].ToString();
                    vendedor.comissao = Convert.ToDecimal(reader["COMISSAO"]);
                    vendedor.endereco = new Endereco();
                    vendedor.endereco.id = Convert.ToInt32(reader["ENDERECO_ID"]);

                    EnderecoRepository enderecoDB = new EnderecoRepository();
                    vendedor.endereco = enderecoDB.ObterPorId(vendedor.endereco.id);
                }

                ConexaoBD.Fechar();
            }

            return vendedor != null ? vendedor : new Vendedor(); //throw new Exception("Não foi possível encontrar nenhum vendedor com esse id!");
        }

        /// <summary>
        /// Obtém todos os registros de vendedores no banco de dados.
        /// </summary>
        /// <returns>Uma lista de objetos Vendedor, ou uma lista vazia se não houver registros.</returns>
        public List<Vendedor> ObterTodos()
        {
            string query = "SELECT * FROM tblVENDEDOR";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            List<Vendedor> listaVendedor = new List<Vendedor>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Vendedor vendedor = new Vendedor();

                    vendedor.id = Convert.ToInt32(reader["ID"]);
                    vendedor.razaoSocial = reader["RAZAO_SOCIAL"].ToString();
                    vendedor.nomeFantasia = reader["NOME_FANTASIA"].ToString();
                    vendedor.email = reader["EMAIL"].ToString();
                    vendedor.senha = reader["SENHA"].ToString();
                    vendedor.cnpj = reader["CNPJ"].ToString();
                    vendedor.comissao = Convert.ToDecimal(reader["COMISSAO"]);
                    vendedor.endereco = new Endereco();
                    vendedor.endereco.id = Convert.ToInt32(reader["ENDERECO_ID"]);

                    EnderecoRepository enderecoDB = new EnderecoRepository();
                    vendedor.endereco = enderecoDB.ObterPorId(vendedor.endereco.id);

                    listaVendedor.Add(vendedor);
                }

                ConexaoBD.Fechar();
            }

            return listaVendedor.Count > 0 ? listaVendedor : new List<Vendedor>(); //throw new Exception("Não foi possível encontrar nenhum vendedor!");

        }

        /// <summary>
        /// Exclui produtos associados a um vendedor no banco de dados.
        /// </summary>
        /// <param name="vendedorID">O ID do vendedor cujos produtos serão excluídos.</param>
        private void ExcluirProdutos(int vendedorID)
        {
            ProdutoRepository produtoDB = new ProdutoRepository();

            List<Produto> listaProduto = SupportSqlConnection.ObterDependentes<ProdutoRepository, Produto>(vendedorID, "SELECT ID FROM tblPRODUTO WHERE VENDEDOR_ID = @Vendedor_id", "@Vendedor_id");
            if (listaProduto.Count > 0)
            {
                foreach (Produto p in listaProduto)
                {
                    produtoDB.Excluir(p);
                }
            }
        }

        /// <summary>
        /// Obtém o ID do último Vendedor adicionado ao banco de dados.
        /// </summary>
        /// <returns>O ID do último Vendedor adicionado.</returns>
        public int ObterUltimoId()
        {
            return SupportSqlConnection.ObterUltimoId("tblVENDEDOR");
        }
    }
}
