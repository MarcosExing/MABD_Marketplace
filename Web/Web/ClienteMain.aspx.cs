//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ClienteMain.

using DAL;
using Model;
using System;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ClienteMain.
    /// </summary>
    public partial class ClienteMain : System.Web.UI.Page
    {
        private static ClienteRepository clienteDB = new ClienteRepository();

        /// <summary>
        /// Carrega o GridView de clientes na página durante o carregamento, se não for uma postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<ClienteRepository, Cliente>(grdClientes);
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
        protected void grdClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int clienteID;

                switch (e.CommandName)
                {
                    case "Detalhes":
                        clienteID = Convert.ToInt32(GridViewManager.GetRowValue(grdClientes, e, 3));

                        Response.Redirect($"ClienteDetalhes.aspx?parametro1={clienteID}");
                        break;

                    case "Editar":
                        clienteID = Convert.ToInt32(GridViewManager.GetRowValue(grdClientes, e, 3));

                        Response.Redirect($"ClienteEditar.aspx?parametro1={clienteID}");
                        break;

                    case "Deletar":
                        clienteID = Convert.ToInt32(GridViewManager.GetRowValue(grdClientes, e, 3));

                        Cliente cliente = clienteDB.ObterPorId(clienteID);
                        if (!clienteDB.Excluir(cliente))
                        {
                            MessageManager.MessagePopUp("Não foi possível deletar o cliente!", ClientScript);
                        }

                        Response.Redirect("ClienteMain.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário para a página de adicionar cliente.
        /// </summary>
        protected void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ClienteAdicionar.aspx");
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }
    }
}