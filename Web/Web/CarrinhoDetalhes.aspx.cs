//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página CarrinhoDetalhes.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página CarrinhoDetalhes.
    /// </summary>
    public partial class CarrinhoDetalhes : System.Web.UI.Page
    {
        /// <summary>
        /// Carrega as informações do carrinho especificado na página, incluindo os dados do cliente e os produtos no carrinho.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int carrinhoId = Convert.ToInt32(Request.QueryString["parametro1"]);
                CarrinhoRepository carrinhoDB = new CarrinhoRepository();
                Carrinho carrinho = carrinhoDB.ObterPorId(carrinhoId);

                lblClienteId.Text = "ID: " + carrinho.cliente.id.ToString();
                lblClienteNome.Text = "Nome: " + carrinho.cliente.nome.ToString();
                lblClienteCpf.Text = "Cpf: " + carrinho.cliente.cpf.ToString();
                lblClienteEmail.Text = "Email: " + carrinho.cliente.email.ToString();
                lblClienteSenha.Text = "Senha: " + carrinho.cliente.senha.ToString();

                grdProdutos.DataSource = carrinho.produtos;
                grdProdutos.DataBind();
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Redireciona o usuário de volta para a página principal dos carrinhos.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CarrinhoMain.aspx");
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }
    }
}