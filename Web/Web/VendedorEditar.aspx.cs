//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página VendedorEditar.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página VendedorEditar.
    /// </summary>
    public partial class VendedorEditar : System.Web.UI.Page
    {
        private static Vendedor vendedor;
        private static VendedorRepository vendedorDB = new VendedorRepository();

        /// <summary>
        /// Carrega os dados do vendedor nos campos de texto na página, se não for postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Carrega os dados do vendedor nos campos de texto na página.
        /// </summary>
        private void LoadTextBox()
        {
            int vendedorID = Convert.ToInt32(Request.QueryString["parametro1"]);

            vendedor = vendedorDB.ObterPorId(vendedorID);

            txtRazaoSocial.Text = vendedor.razaoSocial;
            txtNomeFantasia.Text = vendedor.nomeFantasia;
            txtCnpj.Text = vendedor.cnpj;
            txtEmail.Text = vendedor.email;
            txtSenha.Text = vendedor.senha;
            txtComissao.Text = vendedor.comissao.ToString();

            lblEnderecoSelecionado.Text = $"{vendedor.endereco.cidade}: {vendedor.endereco.estado}";
        }

        /// <summary>
        /// Atualiza as informações do vendedor com base nos dados inseridos nos campos de texto e 
        /// redireciona para a página principal dos vendedores se a atualização for bem-sucedida.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AtualizarVendedor())
                {
                    Response.Redirect("VendedorMain.aspx");
                }
                else
                {
                    MessageManager.MessagePopUp("Não foi possível atualizar o vendedor", ClientScript);
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Atualiza as informações do vendedor no banco de dados com base nos dados inseridos nos campos de texto.
        /// </summary>
        /// <returns>
        /// True se a atualização for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AtualizarVendedor()
        {
            vendedor.razaoSocial = txtRazaoSocial.Text;
            vendedor.nomeFantasia = txtNomeFantasia.Text;
            vendedor.cnpj = txtCnpj.Text;
            vendedor.email = txtEmail.Text;
            vendedor.senha = txtSenha.Text;
            vendedor.comissao = Convert.ToDecimal(txtComissao.Text);

            return vendedorDB.Atualizar(vendedor);
        }

        /// <summary>
        /// Redireciona o usuário para a página principal dos vendedores.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendedorMain.aspx");
        }
    }
}