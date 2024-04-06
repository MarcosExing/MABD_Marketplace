//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página VendedorAdicionar.

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
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página VendedorAdicionar.
    /// </summary>
    public partial class VendedorAdicionar : System.Web.UI.Page
    {
        private static Endereco enderecoSelecionado;
        private static List<Endereco> listaEnderecosDisponiveis;
        private static VendedorRepository vendedorDB = new VendedorRepository();
        private static ClienteRepository clienteDB = new ClienteRepository();
        private static EnderecoRepository enderecoDB = new EnderecoRepository();

        /// <summary>
        /// Carrega os endereços disponíveis no GridView Endereço na página durante o carregamento, se não for uma postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PreencherGridViewEnderecos();

                    lblErroEnderecoIndisponivel.Visible = grdEndereco.Rows.Count == 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Preenche o GridView Endereço com os endereços disponíveis que não estão associados a nenhum cliente ou vendedor.
        /// </summary>
        private void PreencherGridViewEnderecos()
        {
            List<Vendedor> listaVendedor = vendedorDB.ObterTodos();
            List<Cliente> listaCliente = clienteDB.ObterTodos();
            List<Endereco> listaEndereco = enderecoDB.ObterTodos();

            listaEnderecosDisponiveis = listaEndereco;

            if (listaEndereco.Count > 0)
            {

                List<string> listaIdEnderecoUsados = listaVendedor.Count > 0 ?
                    listaVendedor.Select(v => v.endereco.id.ToString()).ToList() : new List<string>();

                listaIdEnderecoUsados.AddRange(listaCliente.Count > 0 ?
                    listaCliente.Select(c => c.endereco.id.ToString()) : new List<string>());

                listaEnderecosDisponiveis = listaEndereco
                    .Where(e => !listaIdEnderecoUsados.Any(eu => e.id.ToString().Contains(eu)))
                    .ToList();
            };

            grdEndereco.DataSource = listaEnderecosDisponiveis;
            grdEndereco.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando enviado pelo GridView, como Adicionar um endereço selecionado.
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
                        MessageManager.MessagePopUp("Não foi possível adicionar o endereço!", ClientScript);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um endereço selecionado e o exibe na tela.
        /// </summary>
        /// <returns>
        /// True se o endereço selecionado for encontrado, False caso contrário.
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
        /// Realiza a validação dos dados selecionados e, se corretos, adiciona o vendedor ao banco de dados e 
        /// redireciona para a página principal dos vendedores.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;

                result += ValidationManager.ErroVisible(lblEnderecoSelecionado, lblErroSemEndereco, lblErroEnderecoIndisponivel);

                if (result == 0)
                {
                    if (AdicionarVendedor())
                    {
                        Response.Redirect("VendedorMain.aspx");
                    }
                    else
                    {
                        MessageManager.MessagePopUp("Algo deu errado ao adicionar o vendedor", ClientScript);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um novo vendedor com os dados fornecidos e o endereço selecionado ao banco de dados.
        /// </summary>
        /// <returns>
        /// True se a adição do vendedor ao banco de dados for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AdicionarVendedor()
        {
            Vendedor vendedor = new Vendedor();

            vendedor.razaoSocial = txtRazaoSocial.Text;
            vendedor.nomeFantasia = txtNomeFantasia.Text;
            vendedor.cnpj = txtCnpj.Text;
            vendedor.email = txtEmail.Text;
            vendedor.senha = txtSenha.Text;
            vendedor.comissao = Convert.ToDecimal(txtComissao.Text);

            vendedor.endereco = enderecoSelecionado;

            return vendedorDB.Adicionar(vendedor);
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