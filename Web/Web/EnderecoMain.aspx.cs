//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página EnderecoMain.

using DAL;
using Model;
using System;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página EnderecoMain.
    /// </summary>
    public partial class EnderecoMain : System.Web.UI.Page
    {
        EnderecoRepository enderecoDB = new EnderecoRepository();

        /// <summary>
        /// Carrega os dados do GridView com os endereços do banco de dados, se não for um postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<EnderecoRepository, Endereco>(grdEnderecos);
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Executa ações com base no comando enviado pelo GridView, como Editar ou Excluir um endereço da tabela.
        /// </summary>
        protected void grdEndereco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int enderecoID;

                switch (e.CommandName)
                {
                    case "Editar":
                        enderecoID = Convert.ToInt32(GridViewManager.GetRowValue(grdEnderecos, e, 2));

                        Response.Redirect($"EnderecoEditar.aspx?parametro1={enderecoID}");
                        break;

                    case "Deletar":
                        enderecoID = Convert.ToInt32(GridViewManager.GetRowValue(grdEnderecos, e, 2));

                        Endereco endereco = enderecoDB.ObterPorId(enderecoID);
                        if (!enderecoDB.Excluir(endereco))
                        {
                            MessageManager.MessagePopUp("Não foi possível excluir o endereço!", ClientScript);
                        }

                        Response.Redirect("EnderecoMain.aspx");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário para a página de adicionar endereço.
        /// </summary>
        protected void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("EnderecoAdicionar.aspx");
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }
    }
}