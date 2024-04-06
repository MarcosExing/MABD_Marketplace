//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página VendedorMain.

using DAL;
using Model;
using System;
using System.Diagnostics;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página VendedorMain.
    /// </summary>
    public partial class VendedorMain : System.Web.UI.Page
    {
        private static VendedorRepository vendedorDB = new VendedorRepository();

        /// <summary>
        /// Carrega o GridView de vendedores na página durante o carregamento, se não for uma postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<VendedorRepository, Vendedor>(grdVendedores);
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
        protected void grdVendedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int vendedorID;

                switch (e.CommandName)
                {
                    case "Detalhes":
                        vendedorID = Convert.ToInt32(GridViewManager.GetRowValue(grdVendedores, e, 3));

                        Response.Redirect($"VendedorDetalhes.aspx?parametro1={vendedorID}");
                        break;

                    case "Editar":
                        vendedorID = Convert.ToInt32(GridViewManager.GetRowValue(grdVendedores, e, 3));

                        Response.Redirect($"VendedorEditar.aspx?parametro1={vendedorID}");
                        break;

                    case "Deletar":
                        vendedorID = Convert.ToInt32(GridViewManager.GetRowValue(grdVendedores, e, 3));

                        Debug.Write($"ID do vendedor: {vendedorID.ToString()}\n");

                        Vendedor vendedor = vendedorDB.ObterPorId(vendedorID);
                        if (!vendedorDB.Excluir(vendedor))
                        {
                            MessageManager.MessagePopUp("Não foi possível deletar o vendedor", ClientScript);
                        }

                        Response.Redirect("VendedorMain.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário para a página de adicionar vendedor.
        /// </summary>
        protected void btnAdicionarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("VendedorAdicionar.aspx");
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }
    }
}