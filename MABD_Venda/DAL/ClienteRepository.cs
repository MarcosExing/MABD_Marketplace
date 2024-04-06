// Este arquivo contém a implementação da classe ClienteRepository, que é responsável pela manipulação dos dados da tabela tblCLIENTE no banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável pelas operações CRUD da tabela tblCLIENTE no banco de dados.
    /// </summary>
    public class ClienteRepository : IRepository<Cliente>
    {
        /// <summary>
        /// Adiciona um novo cliente ao banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Cliente a ser adicionado.</param>
        /// <returns>True se a adição for bem-sucedida, False caso contrário.</returns>
        public bool Adicionar(Cliente entidade)
        {
            string query = "INSERT INTO tblCLIENTE(NOME, CPF, EMAIL, SENHA, ENDERECO_ID) " +
                "VALUES (@Nome, @Cpf, @Email, @Senha, @EnderecoId)";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Nome", entidade.nome);
            cmd.Parameters.AddWithValue("@Cpf", entidade.cpf);
            cmd.Parameters.AddWithValue("@Email", entidade.email);
            cmd.Parameters.AddWithValue("@Senha", entidade.senha);
            cmd.Parameters.AddWithValue("@EnderecoId", entidade.endereco.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Atualiza um objeto Cliente no banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Cliente a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>
        public bool Atualizar(Cliente entidade)
        {
            string query = "UPDATE tblCLIENTE SET " +
                "NOME = @Nome, " +
                "CPF = @Cpf, " +
                "EMAIL = @Email, " +
                "SENHA = @Senha " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Nome", entidade.nome);
            cmd.Parameters.AddWithValue("@Cpf", entidade.cpf);
            cmd.Parameters.AddWithValue("@Email", entidade.email);
            cmd.Parameters.AddWithValue("@Senha", entidade.senha);

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Exclui um objeto Cliente do banco de dados, incluindo a exclusão de seu carrinho associado.
        /// </summary>
        /// <param name="entidade">O objeto Cliente a ser excluído.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public bool Excluir(Cliente entidade)
        {
            ExcluirCarrinho(entidade.id);

            string query = "DELETE FROM tblCLIENTE " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Obtém um cliente do banco de dados com base no ID fornecido.
        /// </summary>
        /// <param name="id">O ID do cliente a ser obtido.</param>
        /// <returns>O cliente correspondente ao ID, ou um novo objeto Cliente se não encontrado.</returns>
        public Cliente ObterPorId(int id)
        {
            string query = "SELECT * FROM tblCLIENTE " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", id);

            Cliente cliente = new Cliente();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    cliente.id = Convert.ToInt32(reader["ID"]);
                    cliente.nome = reader["NOME"].ToString();
                    cliente.cpf = Convert.ToInt64(reader["CPF"]);
                    cliente.email = reader["EMAIL"].ToString();
                    cliente.senha = reader["SENHA"].ToString();
                    cliente.endereco = new Endereco();
                    cliente.endereco.id = Convert.ToInt32(reader["ENDERECO_ID"]);

                    EnderecoRepository enderecoDB = new EnderecoRepository();
                    cliente.endereco = enderecoDB.ObterPorId(cliente.endereco.id); ;
                }

                ConexaoBD.Fechar();
            }

            return cliente != null ? cliente : new Cliente(); //throw new Exception("Não foi possível encontrar nenhum cliente com este id!");
        }

        /// <summary>
        /// Obtém todos os registros de clientes no banco de dados.
        /// </summary>
        /// <returns>Uma lista de objetos Cliente, ou uma lista vazia se nenhum registro for encontrado.</returns>
        public List<Cliente> ObterTodos()
        {
            string query = "SELECT * FROM tblCLIENTE";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            List<Cliente> listaCliente = new List<Cliente>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.id = Convert.ToInt32(reader["ID"]);
                    cliente.nome = reader["NOME"].ToString();
                    cliente.cpf = Convert.ToInt64(reader["CPF"]);
                    cliente.email = reader["EMAIL"].ToString();
                    cliente.senha = reader["SENHA"].ToString();
                    cliente.endereco = new Endereco();
                    cliente.endereco.id = Convert.ToInt32(reader["ENDERECO_ID"]);

                    EnderecoRepository enderecoDB = new EnderecoRepository();
                    Endereco endereco = enderecoDB.ObterPorId(cliente.endereco.id);

                    cliente.endereco = endereco;

                    listaCliente.Add(cliente);
                }

                ConexaoBD.Fechar();
            }

            return listaCliente.Count > 0 ? listaCliente : new List<Cliente>(); //throw new Exception("Não foi possível encontrar nenhum cliente. Verifique se o banco de dados possui algum cliente!");
        }

        /// <summary>
        /// Exclui o carrinho associado a um cliente no banco de dados.
        /// </summary>
        /// <param name="clienteID">O ID do cliente.</param>
        private void ExcluirCarrinho(int clienteID)
        {
            CarrinhoRepository carrinhoDB = new CarrinhoRepository();

            List<Carrinho> listaCarrinho = SupportSqlConnection.ObterDependentes<CarrinhoRepository, Carrinho>(clienteID, "SELECT ID FROM tblCARRINHO WHERE CLIENTE_ID = @Cliente_id", "@Cliente_id");
            if (listaCarrinho.Count > 0)
            {
                foreach (Carrinho c in listaCarrinho)
                {
                    carrinhoDB.Excluir(c);
                }
            }
        }

        /// <summary>
        /// Obtém o ID do último Cliente adicionado ao banco de dados.
        /// </summary>
        /// <returns>O ID do último Cliente adicionado.</returns>
        public int ObterUltimoId()
        {
            return SupportSqlConnection.ObterUltimoId("tblCLIENTE");
        }
    }
}
