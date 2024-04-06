//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ClienteAdicionar.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ClienteAdicionar.
    /// </summary>
    public partial class ClienteAdicionar : System.Web.UI.Page
    {
        private static Endereco enderecoSelecionado;
        private static List<Endereco> listaEnderecosDisponiveis;
        private static ClienteRepository clienteDB = new ClienteRepository();
        private static VendedorRepository vendedorDB = new VendedorRepository();
        private static EnderecoRepository enderecoDB = new EnderecoRepository();
        
        /// <summary>
        /// Carrega os endereços disponíveis no GridView Endereço na página durante o carregamento.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PreencherGridViewEnderecos();
                lblErroEnderecoIndisponivel.Visible = grdEndereco.Rows.Count == 0 ? true : false;
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Preenche o GridView Endereço com os endereços disponíveis (não utilizados por outros clientes ou vendedores).
        /// </summary>
        private void PreencherGridViewEnderecos()
        {
            List<Cliente> listaCliente = clienteDB.ObterTodos();
            List<Vendedor> listaVendedor = vendedorDB.ObterTodos();
            List<Endereco> listaEndereco = enderecoDB.ObterTodos();

            listaEnderecosDisponiveis = listaEndereco;

            if (listaEndereco.Count > 0)
            {
                List<string> listaIdEnderecoUsados = listaCliente.Count > 0 ?
                    listaCliente.Select(c => c.endereco.id.ToString()).ToList() : new List<string>();
                listaIdEnderecoUsados.AddRange(listaVendedor.Count > 0 ?
                    listaVendedor.Select(v => v.endereco.id.ToString()) : new List<string>());

                listaEnderecosDisponiveis = listaEndereco
                    .Where(e => !listaIdEnderecoUsados.Any(eu => e.id.ToString().Contains(eu)))
                    .ToList();
            }

            grdEndereco.DataSource = listaEnderecosDisponiveis;
            grdEndereco.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando envidado pelo GridView, como Adicionar.
        /// </summary>
        protected void grdEndereco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Adicionar")
                {
                    if (AdicionarEndereco(e))
                    {
                        ValidationManager.ErroVisible(lblEnderecoSelecionado, lblErroSemEndereco, lblErroEnderecoIndisponivel);
                    }
                    else
                    {
                        MessageManager.MessagePopUp("Não foi possível adicionar o endereco!", ClientScript);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um endereço selecionado e o mostra na tela.
        /// </summary>
        /// <returns>
        /// True se o endereço for encontrado, False caso contrário.
        /// </returns>
        private bool AdicionarEndereco(GridViewCommandEventArgs e)
        {
            int enderecoID = Convert.ToInt32(GridViewManager.GetRowValue(grdEndereco, e, 0));
            enderecoSelecionado = enderecoDB.ObterPorId(enderecoID);

            if (enderecoSelecionado != null)
            {
                lblEnderecoSelecionado.Text = $"{enderecoSelecionado.cidade}: {enderecoSelecionado.estado}";
                lblEnderecoSelecionado.Visible = true;
                grdEndereco.Visible = false;
            }

            return enderecoSelecionado != null;
        }

        /// <summary>
        /// Realiza a validação dos dados selecionados e, se corretos, adiciona o cliente ao banco de dados e 
        /// redireciona para a página principal dos clientes.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;

                result += ValidationManager.ErroVisible(lblEnderecoSelecionado, lblErroSemEndereco, lblErroEnderecoIndisponivel);

                if (result == 0)
                {
                    if (AdicionarCliente())
                    {
                        Response.Redirect("ClienteMain.aspx");
                    }
                    else
                    {
                        MessageManager.MessagePopUp("Algo deu errado ao adicionar o cliente", ClientScript);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um novo cliente com os dados fornecidos e o endereço selecionado ao banco de dados.
        /// </summary>
        /// <returns>
        /// True se a adição do cliente ao banco de dados for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AdicionarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.nome = txtNome.Text;
            cliente.cpf = Convert.ToInt64(txtCpf.Text);
            cliente.email = txtEmail.Text;
            cliente.senha = txtSenha.Text;

            cliente.endereco = enderecoSelecionado;

            return clienteDB.Adicionar(cliente);
        }

        /// <summary>
        /// Redireciona o usuário a página principal dos clientes.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteMain.aspx");
        }
    }
}