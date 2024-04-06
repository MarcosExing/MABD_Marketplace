// Este arquivo contém a implementação da classe EnderecoRepository, que é responsável pela manipulação dos dados da tabela tblENDERECO no banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável pelas operações CRUD da tabela tblENDERECO no banco de dados.
    /// </summary>
    public class EnderecoRepository : IRepository<Endereco>
    {
        /// <summary>
        /// Adiciona um novo endereço à tabela tblENDERECO no banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Endereco a ser adicionado.</param>
        /// <returns>True se a operação for bem-sucedida, False caso contrário.</returns>
        /// <remarks>
        /// A função utiliza uma instrução SQL para inserir os dados do endereço na tabela,
        /// utilizando parâmetros para evitar injeção de SQL.
        /// </remarks>
        /// <seealso cref="Endereco"/>
        /// <seealso cref="ConexaoBD"/>
        /// <seealso cref="SupportSqlConnection"/>
        public bool Adicionar(Endereco entidade)
        {
            string query = "INSERT INTO tblENDERECO(CEP, CIDADE, ESTADO, RUA, BAIRRO)" +
                "VALUES (@Cep, @Cidade, @Estado, @Rua, @Bairro)";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Cep", entidade.cep);
            cmd.Parameters.AddWithValue("@Cidade", entidade.cidade);
            cmd.Parameters.AddWithValue("@Estado", entidade.estado);
            cmd.Parameters.AddWithValue("@Rua", entidade.rua);
            cmd.Parameters.AddWithValue("@Bairro", entidade.bairro);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Atualiza um objeto Endereco no banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Endereco a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>>
        public bool Atualizar(Endereco entidade)
        {
            string query = "UPDATE tblENDERECO SET " +
                "CEP = @Cep, " +
                "CIDADE = @Cidade, " +
                "ESTADO = @Estado, " +
                "RUA = @Rua, " +
                "BAIRRO = @Bairro " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Cep", entidade.cep);
            cmd.Parameters.AddWithValue("@Cidade", entidade.cidade);
            cmd.Parameters.AddWithValue("@Estado", entidade.estado);
            cmd.Parameters.AddWithValue("@Rua", entidade.rua);
            cmd.Parameters.AddWithValue("@Bairro", entidade.bairro);
            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }

        /// <summary>
        /// Exclui um objeto Endereco do banco de dados, incluindo suas dependências (Vendedores e Clientes associados).
        /// </summary>
        /// <param name="entidade">O objeto Endereco a ser excluído.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public bool Excluir(Endereco entidade)
        {
            ExcluirDependentes(entidade.id);

            string query = "DELETE FROM tblENDERECO " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            return SupportSqlConnection.VericarCmd(cmd);
        }


        /// <summary>
        /// Obtém um objeto Endereco do banco de dados com base no ID fornecido.
        /// </summary>
        /// <param name="id">O ID do Endereco a ser obtido.</param>
        /// <returns>O objeto Endereco correspondente ao ID fornecido, ou um novo objeto Endereco se nenhum for encontrado.</returns>
        public Endereco ObterPorId(int id)
        {
            string query = "SELECT * FROM tblENDERECO " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", id);

            Endereco endereco = new Endereco();

            using (SqlDataReader cmdReader = cmd.ExecuteReader())
            {
                if (cmdReader.Read())
                {
                    endereco.id = Convert.ToInt32(cmdReader["ID"]);
                    endereco.cep = cmdReader["CEP"].ToString();
                    endereco.cidade = cmdReader["CIDADE"].ToString();
                    endereco.estado = cmdReader["ESTADO"].ToString();
                    endereco.rua = cmdReader["RUA"].ToString();
                    endereco.bairro = cmdReader["BAIRRO"].ToString();
                }

                ConexaoBD.Fechar();
            }

            return endereco != null ? endereco : new Endereco(); //throw new Exception ("Não foi possível encontrar nenhum endereco com este id!");
        }

        /// <summary>
        /// Obtém todos os registros de endereço do banco de dados.
        /// </summary>
        /// <returns>Uma lista de endereços, ou uma lista vazia se nenhum registro for encontrado.</returns>
        public List<Endereco> ObterTodos()
        {
            string query = "SELECT * FROM tblENDERECO";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            List<Endereco> enderecoLista = new List<Endereco>();

            using (SqlDataReader cmdReader = cmd.ExecuteReader())
            {
                while (cmdReader.Read())
                {
                    Endereco endereco = new Endereco();

                    endereco.id = Convert.ToInt32(cmdReader["ID"]);
                    endereco.cep = cmdReader["CEP"].ToString();
                    endereco.cidade = cmdReader["CIDADE"].ToString();
                    endereco.estado = cmdReader["ESTADO"].ToString();
                    endereco.rua = cmdReader["RUA"].ToString();
                    endereco.bairro = cmdReader["BAIRRO"].ToString();

                    enderecoLista.Add(endereco);
                }

                ConexaoBD.Fechar();
            }

            return enderecoLista.Count > 0 ? enderecoLista : new List<Endereco>(); //throw new Exception("Não foi possível encontrar nenhum endereco. Verifique se o banco de dados não esta vazio!");
        }

        /// <summary>
        /// Exclui registros dependentes de um endereço no banco de dados, como vendedores e clientes.
        /// </summary>
        /// <param name="enderecoID">O ID do endereço cujos dependentes serão excluídos.</param>
        private void ExcluirDependentes(int enderecoID)
        {
            VendedorRepository vendedorDB = new VendedorRepository();
            ClienteRepository clienteDB = new ClienteRepository();

            List<Vendedor> listaVendedores = SupportSqlConnection.ObterDependentes<VendedorRepository, Vendedor>(enderecoID, "SELECT ID FROM tblVENDEDOR WHERE ENDERECO_ID = @Endereco_id", "@Endereco_id");
            List<Cliente> listaClientes = SupportSqlConnection.ObterDependentes<ClienteRepository, Cliente>(enderecoID, "SELECT ID FROM tblCLIENTE WHERE ENDERECO_ID = @Endereco_id", "@Endereco_id");

            if (listaVendedores.Count > 0)
            {
                foreach (Vendedor v in listaVendedores)
                {
                    vendedorDB.Excluir(v);
                }
            }

            if (listaClientes.Count > 0)
            {
                foreach (Cliente c in listaClientes)
                {
                    clienteDB.Excluir(c);
                }
            }
        }

        /// <summary>
        /// Obtém o ID do último Endereço adicionado ao banco de dados.
        /// </summary>
        /// <returns>O ID do último Endereço adicionado.</returns>
        public int ObterUltimoId()
        {
            return SupportSqlConnection.ObterUltimoId("tblENDERECO");
        }
    }
}
