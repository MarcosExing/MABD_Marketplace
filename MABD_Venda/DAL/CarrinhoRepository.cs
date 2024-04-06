// Este arquivo contém a implementação da classe CarrinhoRepository, que é responsável pela manipulação dos dados das tabelas tblCARRINHO E tblITEM_CARRINHO no banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável pelas operações CRUD das tabelas tblPRODUTO e tblITEM_CARRINHO no banco de dados.
    /// </summary>
    public class CarrinhoRepository : IRepository<Carrinho>
    {
        /// <summary>
        /// Adiciona um objeto Carrinho no banco de dados, incluindo seus itens (Produtos).
        /// </summary>
        /// <param name="entidade">O objeto Carrinho a ser adicionado.</param>
        /// <returns>True se a adição for bem-sucedida, False caso contrário.</returns>
        public bool Adicionar(Carrinho entidade)
        {
            //Inserir os dados da entidade Carrinho na tblCARRINHO
            string query = "INSERT INTO tblCARRINHO(DATA_PEDIDO, VALOR_TOTAL, STATUS_PEDIDO_ID, CLIENTE_ID) " +
                "VALUES(@Data_pedido, @Valor_total, @Status_pedido_id, @Cliente_id)";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Data_pedido", entidade.dataPedido);
            cmd.Parameters.AddWithValue("@Valor_total", entidade.valorTotal);
            cmd.Parameters.AddWithValue("@Status_pedido_id", entidade.statusPedido);
            cmd.Parameters.AddWithValue("@Cliente_id", entidade.cliente.id);

            int result = SupportSqlConnection.VericarCmd(cmd) ? 0 : -1;
            //

            //Obtém o id do carrinho recém adicionado
            entidade.id = ObterUltimoId();

            result += entidade.id != default ? 0 : -1;
            //

            //Inserir na tblITEM_CARRINHO cada produto do carrinho
            result += AdicionarItemCarrinho(entidade.id, entidade.produtos);
            //

            return result == 0;
        }

        /// <summary>
        /// Atualiza um objeto Carrinho no banco de dados e seus itens (Produtos).
        /// </summary>
        /// <param name="entidade">O objeto Carrinho a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>
        public bool Atualizar(Carrinho entidade)
        {
            //Atualizar o carrinho
            string query = "UPDATE tblCARRINHO SET " +
                "DATA_PEDIDO = @Data_pedido, " +
                "VALOR_TOTAL = @Valor_total, " +
                "STATUS_PEDIDO_ID = @Status_pedido_id " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Data_pedido", entidade.dataPedido);
            cmd.Parameters.AddWithValue("@Valor_total", entidade.valorTotal);
            cmd.Parameters.AddWithValue("@Status_pedido_id", entidade.statusPedido);
            cmd.Parameters.AddWithValue("@Id", entidade.id);

            int result = SupportSqlConnection.VericarCmd(cmd) ? 0 : -1;
            //

            //Deletar todos os produtos do carrinho
            result += ExcluirItemCarrinho(entidade.id);
            //

            //Adicionar os produtos novamente no carrinho
            result += AdicionarItemCarrinho(entidade.id, entidade.produtos);
            //

            return result == 0;
        }

        /// <summary>
        /// Exclui um objeto Carrinho e seus Produtos associados do banco de dados.
        /// </summary>
        /// <param name="entidade">O objeto Carrinho a ser excluído.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public bool Excluir(Carrinho entidade)
        {
            //Deletar todos os produtos do carrinho
            int result = ExcluirItemCarrinho(entidade.id);
            //

            //Deletar o carrinho
            string query = "DELETE FROM tblCARRINHO " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", entidade.id);

            result += SupportSqlConnection.VericarCmd(cmd) ? 0 : -1;
            //

            return result == 0;
        }

        /// <summary>
        /// Obtém um carrinho do banco de dados com base no ID, incluindo os Produtos no carrinho.
        /// </summary>
        /// <param name="id">O ID do carrinho a ser obtido.</param>
        /// <returns>O carrinho encontrado ou um novo Carrinho se não for encontrado.</returns>
        public Carrinho ObterPorId(int id)
        {
            //Recuperar o carrinho específico do banco de dados
            string query = "SELECT * FROM tblCARRINHO " +
                "WHERE ID = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Id", id);

            Carrinho carrinho = new Carrinho();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    carrinho.id = Convert.ToInt32(reader["ID"]);
                    carrinho.dataPedido = Convert.ToDateTime(reader["DATA_PEDIDO"]);
                    carrinho.valorTotal = Convert.ToDecimal((reader["VALOR_TOTAL"]));
                    carrinho.statusPedido = Convert.ToInt32(reader["STATUS_PEDIDO_ID"]);
                    carrinho.cliente = new Cliente();
                    carrinho.cliente.id = Convert.ToInt32(reader["CLIENTE_ID"]);

                    ClienteRepository clienteDB = new ClienteRepository();
                    carrinho.cliente = clienteDB.ObterPorId(carrinho.cliente.id);

                }

                ConexaoBD.Fechar();
            }

            int result = carrinho != null ? 0 : -1;
            //

            //Recuperar o id dos produtos no carrinho do banco de dados
            string query2 = "SELECT PRODUTO_ID, QUANTIDADE FROM tblITEM_CARRINHO " +
                "WHERE CARRINHO_ID = @Carrinho_id";

            SqlCommand cmd2 = new SqlCommand(query2, ConexaoBD.Conectar());

            cmd2.Parameters.AddWithValue("@Carrinho_id", id);

            List<Produto> listaProduto = new List<Produto>();

            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produto produto = new Produto();

                    produto.id = Convert.ToInt32(reader["PRODUTO_ID"]);
                    produto.quantidadePedida = Convert.ToDecimal(reader["QUANTIDADE"]);

                    listaProduto.Add(produto);
                }

                ConexaoBD.Fechar();
            }

            carrinho.produtos = listaProduto;
            //

            //Recuperar todas as informações dos produtos que estão no carrinho do banco de dados e adicioná-las ao carrinho
            ProdutoRepository produtoDB = new ProdutoRepository();

            foreach (Produto p in carrinho.produtos)
            {
                Produto produto = produtoDB.ObterPorId(p.id);

                p.descricao = produto.descricao;
                p.preco = produto.preco;
                p.imagem = produto.imagem;
                p.status = produto.status;
                p.vendedor = produto.vendedor;
                p.categoria = produto.categoria;
            }
            //

            return result == 0 ? carrinho : new Carrinho(); //throw new Exception("Não foi possível achar ou Carrinho ou Produto!");
        }

        /// <summary>
        /// Obtém todos os registros de carrinho do banco de dados, incluindo os produtos associados.
        /// </summary>
        /// <returns>Uma lista de objetos Carrinho com informações completas, ou uma lista vazia se nenhum registro for encontrado.</returns>
        public List<Carrinho> ObterTodos()
        {
            //Recuperar todos os carrinhos do banco de dados
            string query = "SELECT * FROM tblCARRINHO";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            List<Carrinho> listaCarrinho = new List<Carrinho>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Carrinho carrinho = new Carrinho();

                    carrinho.id = Convert.ToInt32(reader["ID"]);
                    carrinho.dataPedido = Convert.ToDateTime(reader["DATA_PEDIDO"]);
                    carrinho.valorTotal = Convert.ToDecimal((reader["VALOR_TOTAL"]));
                    carrinho.statusPedido = Convert.ToInt32(reader["STATUS_PEDIDO_ID"]);
                    carrinho.cliente = new Cliente();
                    carrinho.cliente.id = Convert.ToInt32(reader["CLIENTE_ID"]);

                    ClienteRepository clienteDB = new ClienteRepository();
                    carrinho.cliente = clienteDB.ObterPorId(carrinho.cliente.id);

                    listaCarrinho.Add(carrinho);
                }

                ConexaoBD.Fechar();
            }

            int result = listaCarrinho.Count > 0 ? 0 : -1;
            //

            //Recuperar o id de todos os produtos dos carrinhos do banco de dados
            string query2 = "SELECT PRODUTO_ID, QUANTIDADE FROM tblITEM_CARRINHO " +
                "WHERE CARRINHO_ID = @Carrinho_id";

            foreach (Carrinho c in listaCarrinho)
            {
                SqlCommand cmd2 = new SqlCommand(query2, ConexaoBD.Conectar());

                cmd2.Parameters.AddWithValue("@Carrinho_id", c.id);

                List<Produto> listaProduto = new List<Produto>();

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto produto = new Produto();

                        produto.id = Convert.ToInt32(reader["PRODUTO_ID"]);
                        produto.quantidadePedida = Convert.ToDecimal(reader["QUANTIDADE"]);

                        listaProduto.Add(produto);
                    }

                    ConexaoBD.Fechar();
                }

                c.produtos = listaProduto;
            }
            //

            //Recuperar todas as informações dos produtos que estão nos carrinhos do banco de dados e adicioná-las a cada carrinho
            ProdutoRepository produtoDB = new ProdutoRepository();

            foreach (Carrinho c in listaCarrinho)
            {
                foreach (Produto p in c.produtos)
                {
                    Produto produto = produtoDB.ObterPorId(p.id);

                    p.descricao = produto.descricao;
                    p.preco = produto.preco;
                    p.imagem = produto.imagem;
                    p.status = produto.status;
                    p.vendedor = produto.vendedor;
                    p.categoria = produto.categoria;
                }
            }
            //

            return result == 0 ? listaCarrinho : new List<Carrinho>(); //throw new Exception("Não foi possível achar ou os Carrinhos ou os Produtos!");
        }

        /// <summary>
        /// Adiciona produtos do carrinho no banco de dados, na tabela ITEM_CARRINHO.
        /// </summary>
        /// <param name="carrinhoId">O ID do carrinho ao qual os produtos estão associados.</param>
        /// <param name="produtos">A lista de produtos a serem adicionados ao carrinho (no caso a tabela de associação ITEM_CARRINHO).</param>
        /// <returns>O número total de operações bem-sucedidas (0 se todas as operações foram bem-sucedidas, -1 caso contrário).</returns>
        private int AdicionarItemCarrinho(int carrinhoId, List<Produto> produtos)
        {
            int result = 0;

            string query = "INSERT INTO tblITEM_CARRINHO(QUANTIDADE, TOTAL, CARRINHO_ID, PRODUTO_ID) " +
                           "VALUES(@Quantidade, @Total, @Carrinho_id, @Produto_id)";

            foreach (Produto p in produtos)
            {
                SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

                cmd.Parameters.AddWithValue("@Quantidade", p.quantidadePedida);
                cmd.Parameters.AddWithValue("@Total", p.quantidadePedida * p.preco);
                cmd.Parameters.AddWithValue("@Carrinho_id", carrinhoId);
                cmd.Parameters.AddWithValue("@Produto_id", p.id);

                result += SupportSqlConnection.VericarCmd(cmd) ? 0 : -1;
            }

            return result;
        }

        /// <summary>
        /// Exclui todos os itens de um carrinho no banco de dados, através da tabela ITEM_CARRINHO.
        /// </summary>
        /// <param name="carrinhoId">O ID do carrinho do qual os itens serão excluídos.</param>
        /// <returns>O número total de operações bem-sucedidas (0 se todas as operações foram bem-sucedidas, -1 caso contrário).</returns>
        private int ExcluirItemCarrinho(int carrinhoId)
        {
            string query = "DELETE FROM tblITEM_CARRINHO " +
                           "WHERE CARRINHO_ID = @Carrinho_id";

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue("@Carrinho_id", carrinhoId);

            int result = SupportSqlConnection.VericarCmd(cmd) ? 0 : -1;

            return result;
        }

        /// <summary>
        /// Obtém o ID do último Carrinho adicionado ao banco de dados.
        /// </summary>
        /// <returns>O ID do último Carrinho adicionado.</returns>
        public int ObterUltimoId()
        {
            return SupportSqlConnection.ObterUltimoId("tblCARRINHO");
        }
    }
}
