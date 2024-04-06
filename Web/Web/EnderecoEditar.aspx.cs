//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página EnderecoEditar.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página EnderecoEditar.
    /// </summary>
    public partial class EnderecoEditar : System.Web.UI.Page
    {
        private static Endereco endereco;
        private static EnderecoRepository enderecoDB = new EnderecoRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadLabels();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Carrega as informações de um endereço para exibição nos campos da página.
        /// </summary>
        private void LoadLabels()
        {
            int enderecoId = Convert.ToInt32(Request.QueryString["parametro1"]);
            endereco = enderecoDB.ObterPorId(enderecoId);

            txtCep.Text = endereco.cep;
            txtCidade.Text = endereco.cidade;
            txtEstado.Text = endereco.estado;
            txtRua.Text = endereco.rua;
            txtBairro.Text = endereco.bairro;
        }

        /// <summary>
        /// Atualiza o endereço no banco de dados e redireciona o usuário para a página principal de endereços.
        /// </summary>
        protected void btnConfirmarEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                if (AtualizarEndereco())
                {
                    Response.Redirect("EnderecoMain.aspx");
                }

                else
                {
                    MessageManager.MessagePopUp("Não foi possível atualizar o endereço!", ClientScript);
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Atualiza um objeto Endereco no banco de dados com base nos dados inseridos nos campos da página.
        /// </summary>
        /// <returns>
        /// True se a atualização for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AtualizarEndereco()
        {
            endereco.cep = txtCep.Text;
            endereco.cidade = txtCidade.Text;
            endereco.estado = txtEstado.Text;
            endereco.rua = txtRua.Text;
            endereco.bairro = txtBairro.Text;

            return enderecoDB.Atualizar(endereco);
        }

        /// <summary>
        /// Redireciona o usuário para a página principal de endereços.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnderecoMain.aspx");
        }
    }
}