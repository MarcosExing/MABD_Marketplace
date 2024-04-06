//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ProdutoMain.

using DAL;
using Model;
using System;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ProdutoMain.
    /// </summary>
    public partial class ProdutoMain : System.Web.UI.Page
    {
        private static ProdutoRepository produtoDB = new ProdutoRepository();

        /// <summary>
        /// Carrega o GridView de produtos na página durante o carregamento, se não for uma postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<ProdutoRepository, Produto>(grdProdutos);
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Executa ações com base no comando envidado pelo GridView, como Detalhes, Editar e Deletar.
        /// </summary>
        protected void grdProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int produtoID;

                switch (e.CommandName)
                {
                    case "Detalhes":
                        produtoID = Convert.ToInt32(GridViewManager.GetRowValue(grdProdutos, e, 3));

                        Response.Redirect($"ProdutoDetalhes.aspx?parametro1={produtoID}");
                        break;

                    case "Editar":
                        produtoID = Convert.ToInt32(GridViewManager.GetRowValue(grdProdutos, e, 3));

                        Response.Redirect($"ProdutoEditar.aspx?parametro1={produtoID}");
                        break;

                    case "Deletar":
                        produtoID = Convert.ToInt32(GridViewManager.GetRowValue(grdProdutos, e, 3));

                        Produto produto = produtoDB.ObterPorId(produtoID);
                        if (!produtoDB.Excluir(produto))
                        {
                            MessageManager.MessagePopUp("Não foi possível deletar o produto!", ClientScript);
                        }

                        Response.Redirect("ProdutoMain.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário para a página de adicionar produto.
        /// </summary>
        protected void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdutoAdicionar.aspx");
        }
    }
}