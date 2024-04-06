//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ClienteEditar.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ClienteEditar.
    /// </summary>
    public partial class ClienteEditar : System.Web.UI.Page
    {
        private static Cliente cliente;
        private static ClienteRepository clienteDB = new ClienteRepository();

        /// <summary>
        /// Carrega os dados do cliente nos campos de texto da página, se não for uma operação de postback.
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
        /// Carrega os dados do cliente nos campos de texto da página.
        /// </summary>
        private void LoadTextBox()
        {
            int clienteID = Convert.ToInt32(Request.QueryString["parametro1"]);

            cliente = clienteDB.ObterPorId(clienteID);

            txtNome.Text = cliente.nome;
            txtCpf.Text = cliente.cpf.ToString();
            txtEmail.Text = cliente.email;
            txtSenha.Text = cliente.senha;

            lblEnderecoSelecionado.Text = $"{cliente.endereco.cidade}: {cliente.endereco.estado}";
        }

        /// <summary>
        /// Atualiza as informações do cliente com base nos dados inseridos nos campos de texto e redireciona 
        /// para a página principal dos clientes em caso de sucesso.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AtualizarCliente())
                {
                    Response.Redirect("ClienteMain.aspx");
                }
                else
                {
                    MessageManager.MessagePopUp("Não foi possível atualizar o cliente", ClientScript);
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Atualiza as informações do cliente no banco de dados com base nos dados inseridos nos campos de texto.
        /// </summary>
        /// <returns>
        /// True se a atualização for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AtualizarCliente()
        {
            cliente.nome = txtNome.Text;
            cliente.cpf = Convert.ToInt64(txtCpf.Text);
            cliente.email = txtEmail.Text;
            cliente.senha = txtSenha.Text;

            return clienteDB.Atualizar(cliente);
        }

        /// <summary>
        /// Redireciona o usuário para a página principal dos clientes.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteMain.aspx");
        }
    }
}