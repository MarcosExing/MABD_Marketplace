//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ClienteDetalhes.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ClienteDetalhes.
    /// </summary>
    public partial class ClienteDetalhes : System.Web.UI.Page
    {
        private static ClienteRepository clienteDB = new ClienteRepository();

        /// <summary>
        /// Carrega as informações do cliente e seu endereço associado nos respectivos labels da página.
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
        /// Carrega os dados do cliente e seu endereço nos labels correspondentes na página.
        /// </summary>
        private void LoadLabels()
        {
            int clienteID = Convert.ToInt32(Request.QueryString["parametro1"]);
            Cliente cliente = clienteDB.ObterPorId(clienteID);

            lblClienteId.Text = "ID: " + cliente.id.ToString();
            lblClienteCpf.Text = "Cpf: " + cliente.cpf.ToString();
            lblClienteNome.Text = "Nome: " + cliente.nome;
            lblClienteEmail.Text = "Email: " + cliente.email;
            lblClienteSenha.Text = "Senha: " + cliente.senha;

            lblEnderecoId.Text = "ID: " + cliente.endereco.id.ToString();
            lblEnderecoCep.Text = "Cep: " + cliente.endereco.cep;
            lblEnderecoCidade.Text = "Cidade: " + cliente.endereco.cidade;
            lblEnderecoEstado.Text = "Estado: " + cliente.endereco.estado;
            lblEnderecoRua.Text = "Rua: " + cliente.endereco.rua;
            lblEnderecoBairro.Text = "Bairro: " + cliente.endereco.bairro;
        }

        /// <summary>
        /// Redireciona o usuário de volta para a página principal dos clientes.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ClienteMain.aspx");
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }
    }
}