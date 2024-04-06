//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página VendedorDetalhes.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página VendedorDetalhes.
    /// </summary>
    public partial class VendedorDetalhes : System.Web.UI.Page
    {
        private static VendedorRepository vendedorDB = new VendedorRepository();

        /// <summary>
        /// Carrega as informações do vendedor e endereço associado nas labels da página.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLabels();
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Carrega as labels com as informações do vendedor e endereço associado.
        /// </summary>
        private void LoadLabels()
        {
            int vendedorID = Convert.ToInt32(Request.QueryString["parametro1"]);
            Vendedor vendedor = vendedorDB.ObterPorId(vendedorID);

            lblVendedorId.Text = "ID: " + vendedorID.ToString();
            lblVendedorRazaoSocial.Text = "Razão Social: " + vendedor.razaoSocial;
            lblVendedorNomeFantasia.Text = "Nome Fantasia: " + vendedor.nomeFantasia;
            lblVendedorCnpj.Text = "Cnpj: " + vendedor.cnpj;
            lblVendedorEmail.Text = "Email: " + vendedor.email;
            lblVendedorSenha.Text = "Senha: " + vendedor.senha;
            lblVendedorComissao.Text = "Comissão: " + vendedor.comissao.ToString();

            lblEnderecoId.Text = "ID: " + vendedor.endereco.id.ToString();
            lblEnderecoCep.Text = "Cep: " + vendedor.endereco.cep;
            lblEnderecoCidade.Text = "Cidade: " + vendedor.endereco.cidade;
            lblEnderecoEstado.Text = "Estado: " + vendedor.endereco.estado;
            lblEnderecoRua.Text = "Rua: " + vendedor.endereco.rua;
            lblEnderecoBairro.Text = "Bairro: " + vendedor.endereco.bairro;
        }

        /// <summary>
        /// Redireciona o usuário de volta para a página principal dos vendedores.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("VendedorMain.aspx");
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }
    }
}