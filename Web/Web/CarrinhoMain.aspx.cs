//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página CarrinhoMain.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página CarrinhoMain.
    /// </summary>
    public partial class CarrinhoMain : System.Web.UI.Page
    {
        private static CarrinhoRepository carrinhoDB = new CarrinhoRepository();

        /// <summary>
        /// Carrega o GridView de produtos na página durante o carregamento, se não for uma postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CarregarGridView();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Atualiza o valor total de cada carrinho no banco de dados e carrega os dados no GridView.
        /// </summary>
        private void CarregarGridView()
        {
            List<Carrinho> listaCarrinhos = carrinhoDB.ObterTodos();

            foreach (Carrinho c in listaCarrinhos)
            {
                c.valorTotal = 0;

                foreach (Produto p in c.produtos)
                {
                    c.valorTotal += p.preco * p.quantidadePedida;
                }

                carrinhoDB.Atualizar(c);
            }

            grdCarrinhos.DataSource = listaCarrinhos;
            grdCarrinhos.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando envidado pelo GridView, como Detalhes, Editar e Deletar.
        /// </summary>
        protected void grdCarrinhos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int carrinhoID;

                switch (e.CommandName)
                {
                    case "Detalhes":
                        carrinhoID = Convert.ToInt32(GridViewManager.GetRowValue(grdCarrinhos, e, 3));

                        Response.Redirect($"CarrinhoDetalhes.aspx?parametro1={carrinhoID}");
                        break;

                    case "Editar":
                        carrinhoID = Convert.ToInt32(GridViewManager.GetRowValue(grdCarrinhos, e, 3));

                        Response.Redirect($"CarrinhoEditar.aspx?parametro1={carrinhoID}");
                        break;

                    case "Deletar":
                        carrinhoID = Convert.ToInt32(GridViewManager.GetRowValue(grdCarrinhos, e, 3));

                        Carrinho carrinho = carrinhoDB.ObterPorId(carrinhoID);
                        if (!carrinhoDB.Excluir(carrinho))
                        {
                            MessageManager.MessagePopUp("Não foi possível deletar o carrinho!", ClientScript);
                        }

                        Response.Redirect("CarrinhoMain.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário para a página de adicionar carrinho.
        /// </summary>
        protected void btnAdicionarCarrinho_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarrinhoAdicionar.aspx");
        }
    }
}