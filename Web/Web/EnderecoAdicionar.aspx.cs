//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página EnderecoAdicionar.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página EnderecoAdicionar.
    /// </summary>
    public partial class EnderecoAdicionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método chamado quando o botão "Confirmar Endereço" é clicado.
        /// Adiciona um novo endereço ao banco de dados.
        /// </summary>
        protected void btnConfirmarEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                EnderecoRepository enderecoDB = new EnderecoRepository();
                Endereco endereco = new Endereco(txtCep.Text, txtCidade.Text, txtEstado.Text, txtRua.Text, txtBairro.Text);

                if (enderecoDB.Adicionar(endereco))
                {
                    Response.Redirect("EnderecoMain.aspx");
                }

                else
                {
                    MessageManager.MessagePopUp("Não foi possível adicionar um endereço!", ClientScript);
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
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnderecoMain.aspx");
        }
    }
}