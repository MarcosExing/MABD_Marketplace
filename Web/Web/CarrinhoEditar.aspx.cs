//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página CarrinhoEditar.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página CarrinhoEditar.
    /// </summary>
    public partial class CarrinhoEditar : System.Web.UI.Page
    {
        private static Carrinho carrinho;
        private static List<Produto> listaProdutosSelecionados = new List<Produto>();
        private static List<Produto> listaProdutosDisponiveis = new List<Produto>();
        private CarrinhoRepository carrinhoDB = new CarrinhoRepository();
        private ProdutoRepository produtoDB = new ProdutoRepository();

        /// <summary>
        /// Carrega as informações iniciais da página, como os dados do carrinho, a lista de produtos disponíveis,
        /// e preenche os campos correspondentes, como data do pedido, valor total, cliente selecionado,
        /// e produtos selecionados anteriormente, além de configurar o dropdown de status do pedido.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PreencherInformaçõesAnteriores();

                    PreencherGridViewProdutos();
                    lblErroProdutoIndisponivel.Visible = listaProdutosDisponiveis.Count == 0 ? true : false;

                    PreencherDropdownStatus();
                    ddlStatusPedido.Text = carrinho.statusPedido == 1 ? "Disponível" : "Indisponível";
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Preenche os campos da página com as informações anteriores do carrinho, como a data do pedido,
        /// o valor total, o cliente selecionado e os produtos selecionados anteriormente.
        /// </summary>
        private void PreencherInformaçõesAnteriores()
        {
            int carrinhoId = Convert.ToInt32(Request.QueryString["parametro1"]);
            carrinho = carrinhoDB.ObterPorId(carrinhoId);

            txtDataPedido.Text = String.Format("{0:yyyy-MM-dd}", carrinho.dataPedido);
            lblValorTotalPlaceHolder.Text = carrinho.valorTotal.ToString();
            lblClienteSelecionado.Text = carrinho.cliente.nome;
            lblProdutosSelecionadosPlaceHolder.Text = String.Concat(carrinho.produtos.Select(p => $"{p.descricao} ({p.quantidadePedida.ToString()}), "));

            listaProdutosSelecionados.Clear();
        }

        /// <summary>
        /// Preenche o GridView de produtos com a lista de produtos disponíveis.
        /// </summary>
        private void PreencherGridViewProdutos()
        {
            listaProdutosDisponiveis.Clear();
            List<Produto> listaProduto = produtoDB.ObterTodos();

            listaProdutosDisponiveis.AddRange(listaProduto.Count > 0 ?
                listaProduto.Where(p => p.status) : new List<Produto>());

            grdProdutos.DataSource = listaProdutosDisponiveis;
            grdProdutos.DataBind();
        }

        /// <summary>
        /// Preenche o dropdown de status do pedido com as opções "Disponível" e "Indisponível".
        /// </summary>
        private void PreencherDropdownStatus()
        {
            string[] listaStatus = { "Disponível", "Indisponível" };
            ddlStatusPedido.DataSource = listaStatus;
            ddlStatusPedido.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando enviado pelo GridView, como adicionar um produto ao carrinho.
        /// </summary>
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AdicionarProduto")
                {
                    if (AdicionarProdutos(e))
                    {
                        ValidationManager.ErroVisible(lblProdutosSelecionados, lblErroSemProduto, lblErroProdutoIndisponivel);

                    }
                    else
                    {
                        MessageManager.MessagePopUp("Não foi possível adicionar o produto!", ClientScript);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona o produto selecionado ao carrinho e atualiza as informações exibidas na tela,
        /// como a lista de produtos selecionados e o valor total do carrinho.
        /// </summary>
        /// <returns>
        /// True se o produto for adicionado com sucesso, False caso contrário.
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

                //Esconde os placeholders e as mensagem de erro sem produto
                lblProdutosSelecionadosPlaceHolder.Visible = false;
                lblValorTotalPlaceHolder.Visible = false;
                lblErroSemProduto.Visible = false;
                //

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
                //

                //Atualiza a lista de produtos para remover o produto selecionado
                listaProdutosDisponiveis.RemoveAt(listaProdutosDisponiveis.FindIndex(p => p.id == produto.id));
                grdProdutos.DataSource = listaProdutosDisponiveis;
                grdProdutos.DataBind();
                //

                txtQuantidadePedida.Enabled = true;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Realiza a validação dos dados selecionados e, se corretos, adiciona o carrinho ao banco de dados e
        /// redireciona para a página principal dos carrinhos.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                result += ValidationManager.ErroVisible(lblProdutosSelecionados, lblErroSemProduto, lblErroProdutoIndisponivel);

                if (result == 0)
                {
                    if (AtualizarCarrinho())
                    {
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
        /// Atualiza as informações do carrinho no banco de dados.
        /// </summary>
        /// <returns>
        /// True se a atualização for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AtualizarCarrinho()
        {
            carrinho.dataPedido = Convert.ToDateTime(txtDataPedido.Text);
            carrinho.valorTotal = Convert.ToDecimal(txtValorTotal.Text);
            carrinho.statusPedido = ddlStatusPedido.Text == "Disponível" ? 1 : 0;
            carrinho.produtos = listaProdutosSelecionados;

            return carrinhoDB.Atualizar(carrinho);
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