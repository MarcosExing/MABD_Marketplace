using System;
using System.Web.UI;

namespace Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEndereco_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnderecoMain.aspx");
        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteMain.aspx");
        }

        protected void btnVendedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendedorMain.aspx");
        }

        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaMain.aspx");
        }

        protected void btnProduto_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdutoMain.aspx");
        }

        protected void btnCarrinho_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarrinhoMain.aspx");
        }
    }
}