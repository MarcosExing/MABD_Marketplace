//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página CategoriaMain.

using DAL;
using Model;
using System;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página CategoriaMain.
    /// </summary>
    public partial class CategoriaMain : System.Web.UI.Page
    {
        private static CategoriaRepository categoriaDB = new CategoriaRepository();

        /// <summary>
        /// Carrega o GridView de categorias na página durante o carregamento, se não for uma postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<CategoriaRepository, Categoria>(grdCategorias);
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
        protected void grdCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int categoriaID;

                switch (e.CommandName)
                {
                    case "Editar":
                        categoriaID = Convert.ToInt32(GridViewManager.GetRowValue(grdCategorias, e, 2));

                        Response.Redirect($"CategoriaEditar.aspx?parametro1={categoriaID}");
                        break;

                    case "Deletar":
                        categoriaID = Convert.ToInt32(GridViewManager.GetRowValue(grdCategorias, e, 2));
                        Categoria categoria = categoriaDB.ObterPorId(categoriaID);

                        if (categoria != null)
                        {
                            categoriaDB.Excluir(categoria);
                        }

                        Response.Redirect("CategoriaMain.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário para a página de adicionar categoria.
        /// </summary>
        protected void btnAdicionarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaAdicionar.aspx");
        }
    }
}