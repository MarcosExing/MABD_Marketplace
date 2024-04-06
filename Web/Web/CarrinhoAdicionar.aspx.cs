//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página CarrinhoAdicionar.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página CarrinhoAdicionar.
    /// </summary>
    public partial class CarrinhoAdicionar : System.Web.UI.Page
    {
        private static Cliente clienteSelecionado;
        private static List<Produto> listaProdutosSelecionados = new List<Produto>();
        private static List<Cliente> listaClientesDisponiveis = new List<Cliente>();
        private static List<Produto> listaProdutosDisponiveis = new List<Produto>();
        private CarrinhoRepository carrinhoDB = new CarrinhoRepository();
        private ClienteRepository clienteDB = new ClienteRepository();
        private ProdutoRepository produtoDB = new ProdutoRepository();

        /// <summary>
        /// Carrega dados iniciais na página, como clientes e produtos, e preenche o dropdown de status do pedido.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PreencherGridViewClientes();
                    lblErroClienteIndisponivel.Visible = grdCliente.Rows.Count == 0;

                    PreencherGridViewProdutos();
                    lblErroProdutoIndisponivel.Visible = grdProdutos.Rows.Count == 0;

                    PreencherDropdownStatus();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Preenche o GridView Cliente com os clientes disponíveis que ainda não foram associados a um carrinho.
        /// </summary>
        private void PreencherGridViewClientes()
        {
            listaClientesDisponiveis.Clear();

            List<Carrinho> listaCarrinho = carrinhoDB.ObterTodos();
            List<Cliente> listaCliente = clienteDB.ObterTodos();

            listaClientesDisponiveis = listaCliente;

            if (listaCliente.Count > 0)
            {
                List<string> listaIdClientesUsados = listaCarrinho.Count > 0 ?
                    listaCarrinho.Select(c => c.cliente.id.ToString()).ToList() : new List<string>();

                listaClientesDisponiveis = listaCliente
                    .Where(c => !listaIdClientesUsados.Any(p => c.id.ToString().Contains(p)))
                    .ToList();
            }

            grdCliente.DataSource = listaClientesDisponiveis;
            grdCliente.DataBind();
        }

        /// <summary>
        /// Preenche o GridView Produtos com os produtos disponíveis para adição ao carrinho.
        /// </summary>
        private void PreencherGridViewProdutos()
        {
            listaProdutosDisponiveis.Clear();
            List<Produto> listaProduto = produtoDB.ObterTodos();

            if (listaProduto.Count > 0)
            {
                listaProdutosDisponiveis.AddRange(listaProduto.Where(p => p.status));
            }
            else
            {
                listaProdutosDisponiveis = listaProduto;
            }

            grdProdutos.DataSource = listaProdutosDisponiveis;
            grdProdutos.DataBind();
        }

        /// <summary>
        /// Preenche o dropdown de status do pedido.
        /// </summary>
        private void PreencherDropdownStatus()
        {
            string[] listaStatus = { "Disponível", "Indisponível" };
            ddlStatusPedido.DataSource = listaStatus;
            ddlStatusPedido.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando enviado pelo GridView, como adicionar cliente ou produto ao carrinho.
        /// </summary>
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "AdicionarVendedor":
                        if (AdicionarCliente(e))
                        {
                            ValidationManager.ErroVisible(lblClienteSelecionado, lblErroSemCliente, lblErroClienteIndisponivel);
                        }
                        else
                        {
                            MessageManager.MessagePopUp("Não foi possível adicionar o cliente!", ClientScript);
                        }
                        break;

                    case "AdicionarProduto":
                        if (AdicionarProdutos(e))
                        {
                            ValidationManager.ErroVisible(lblProdutosSelecionados, lblErroSemProduto, lblErroProdutoIndisponivel);
                        }
                        else
                        {
                            MessageManager.MessagePopUp("Não foi possível adicionar o produto!", ClientScript);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um cliente selecionado ao carrinho e o exibe na tela.
        /// </summary>
        /// <returns>
        /// True se o cliente selecionado for encontrado, False caso contrário.
        /// </returns>
        private bool AdicionarCliente(GridViewCommandEventArgs e)
        {
            int clienteID = Convert.ToInt32(GridViewManager.GetRowValue(grdCliente, e, 0));
            clienteSelecionado = clienteDB.ObterPorId(clienteID);

            if (clienteSelecionado != null)
            {
                lblClienteSelecionado.Text = clienteSelecionado.nome;
                lblClienteSelecionado.Visible = true;
                grdCliente.Visible = false;
            }

            return clienteSelecionado != null;
        }

        /// <summary>
        /// Adiciona produtos selecionados ao carrinho e os mostra na tela.
        /// </summary>
        /// <returns>
        /// True se o produto selecionado for encontrado, False caso contrário.
        /// </returns>
        private bool AdicionarProdutos(GridViewCommandEventArgs e)
        {
            //Obtem o ID e o textBox da linha
            int produtoID = Convert.ToInt32(GridViewManager.GetRowValue(grdProdutos, e, 0));

            TextBox txtQuantidadePedida = (TextBox)GridViewManager.GetRowObject(grdProdutos, e, 5, "txtQuantidadePedida");
            decimal quantidadePedida = txtQuantidadePedida.Text.Length > 0 ? Convert.ToDecimal(txtQuantidadePedida.Text) : 0;
            //

            if (produtoID != default && quantidadePedida > 0)
            {
                txtQuantidadePedida.Enabled = false;

                //Adiciona o produto com a quantidade pedida a lista de produtos selecionados
                Produto produto = produtoDB.ObterPorId(produtoID);

                produto.quantidadePedida = quantidadePedida;
                listaProdutosSelecionados.Add(produto);
                //

                //Atualiza a label responsável por mostrar os produtos selecionados ao usuário
                lblProdutosSelecionados.Text += produto.descricao + " (" + produto.quantidadePedida.ToString() + "), ";
                lblProdutosSelecionados.Visible = true;
                //

                //Calcula o valor total
                decimal valorTotal = Convert.ToDecimal(txtValorTotal.Text);
                valorTotal += produto.quantidadePedida * produto.preco;
                txtValorTotal.Text = valorTotal.ToString();
                Debug.Write($"Valor total: {valorTotal.ToString()}\n");
                //

                //Atualiza a lista de produtos para remover o produto selecionado
                listaProdutosDisponiveis.RemoveAt(listaProdutosDisponiveis.FindIndex(p => p.id == produto.id));
                grdProdutos.DataSource = listaProdutosDisponiveis;
                grdProdutos.DataBind();
                //

                txtQuantidadePedida.Enabled = true;

                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Realiza a validação dos dados selecionados e, se corretos, adiciona o carrinho ao banco de dados e 
        /// redireciona para a página principal do carrinho.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                result += ValidationManager.ErroVisible(lblClienteSelecionado, lblErroSemCliente, lblErroClienteIndisponivel);
                result += ValidationManager.ErroVisible(lblProdutosSelecionados, lblErroSemProduto, lblErroProdutoIndisponivel);

                if (result == 0)
                {
                    if (AdicionarCarrinho())
                    {
                        ValidationManager.ErroVisible(lblClienteSelecionado, lblErroSemCliente, lblErroClienteIndisponivel);
                        ValidationManager.ErroVisible(lblProdutosSelecionados, lblErroSemProduto, lblErroProdutoIndisponivel);
                        Response.Redirect("CarrinhoMain.aspx");
                    }
                    else
                    {
                        MessageManager.MessagePopUp("Algo deu errado ao adicionar o carrinho!", ClientScript);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um novo carrinho ao banco de dados com os dados fornecidos.
        /// </summary>
        /// <returns>
        /// True se a adição do carrinho ao banco de dados for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AdicionarCarrinho()
        {
            Carrinho carrinho = new Carrinho();

            carrinho.dataPedido = Convert.ToDateTime(txtDataPedido.Text);
            carrinho.valorTotal = Convert.ToDecimal(txtValorTotal.Text);
            carrinho.statusPedido = ddlStatusPedido.Text == "Disponível" ? 1 : 0;
            carrinho.cliente = clienteSelecionado;
            carrinho.produtos = listaProdutosSelecionados;

            return carrinhoDB.Adicionar(carrinho);
        }

        /// <summary>
        /// Redireciona o usuário para a página principal dos carrinhos.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarrinhoMain.aspx");
        }
    }
}