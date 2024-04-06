//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ProdutoDetalhes.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ProdutoDetalhes.
    /// </summary>
    public partial class ProdutoDetalhes : System.Web.UI.Page
    {
        private static ProdutoRepository produtoDB = new ProdutoRepository();

        /// <summary>
        /// Carrega as informações do produto e do vendedor em labels na página, se não for um postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLabels();
            }
        }

        /// <summary>
        /// Carrega as informações do produto e do vendedor em labels na página.
        /// </summary>
        private void LoadLabels()
        {
            int produtoID = Convert.ToInt32(Request.QueryString["parametro1"]);
            Produto produto = produtoDB.ObterPorId(produtoID);

            lblProdutoId.Text = "ID: " + produto.id.ToString();
            lblProdutoCategoria.Text = "Categoria: " + produto.categoria.nome;
            lblProdutoDescricao.Text = "Descrição: " + produto.descricao;
            lblProdutoPreco.Text = "Preço: R$:" + String.Format("{0:N2}", produto.preco);
            imgProdutoImagem.ImageUrl = produto.imagem;
            lblProdutoStatus.Text = "Status do Produto: " + produto.status.ToString();

            lblVendedorId.Text = "ID: " + produto.vendedor.id.ToString();
            lblVendedorRazaoSocial.Text = "Razão Social: " + produto.vendedor.razaoSocial;
            lblVendedorNomeFantasia.Text = "Nome Fantasia: " + produto.vendedor.nomeFantasia;
            lblVendedorCnpj.Text = "Cnpj: " + produto.vendedor.cnpj;
            lblVendedorEmail.Text = "Email: " + produto.vendedor.email;
            lblVendedorSenha.Text = "Senha: " + produto.vendedor.senha;
            lblVendedorComissao.Text = "Comissão: " + produto.vendedor.comissao.ToString();
        }

        /// <summary>
        /// Redireciona o usuário para a página principal dos produtos.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdutoMain.aspx");
        }
    }
}