//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ProdutoAdicionar.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ProdutoAdicionar.
    /// </summary>
    public partial class ProdutoAdicionar : System.Web.UI.Page
    {
        private static Categoria categoriaSelecionada;
        private static Vendedor vendedorSelecionado;
        private static List<Vendedor> listaVendedoresDisponiveis = new List<Vendedor>();
        private static string imageSavePath = String.Empty;
        private VendedorRepository vendedorDB = new VendedorRepository();
        private CategoriaRepository categoriaDB = new CategoriaRepository();
        private ProdutoRepository produtoDB = new ProdutoRepository();

        /// <summary>
        /// Carrega dados iniciais na página, como categorias e vendedores, e preenche o dropdown de status de produto.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<CategoriaRepository, Categoria>(grdCategoria);
                    lblErroCategoriaIndisponivel.Visible = grdCategoria.Rows.Count == 0;

                    GridViewManager.CarregarGridView<VendedorRepository, Vendedor>(grdVendedores);
                    lblErroVendedorIndisponivel.Visible = grdVendedores.Rows.Count == 0;

                    PreencherDropdownStatus();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Preenche o dropdown de status do produto.
        /// </summary>
        private void PreencherDropdownStatus()
        {
            string[] listaStatus = { "Disponível", "Indisponível" };
            ddlStatusProduto.DataSource = listaStatus;
            ddlStatusProduto.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando enviado pelo GridView, como adicionar categoria ou vendedor.
        /// </summary>
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "AdicionarCategoria":
                        if (AdicionarCategoria(e))
                        {
                            ValidationManager.ErroVisible(lblCategoriaSelecionada, lblErroSemCategoria, lblErroCategoriaIndisponivel);
                        }
                        else
                        {
                            MessageManager.MessagePopUp("Não foi possível adicionar a categoria!", ClientScript);
                        }
                        break;

                    case "AdicionarVendedor":
                        if (AdicionarVendedor(e))
                        {
                            ValidationManager.ErroVisible(lblVendedorSelecionado, lblErroSemVendedor, lblErroVendedorIndisponivel);
                        }
                        else
                        {
                            MessageManager.MessagePopUp("Não foi possível adicionar o vendedor!", ClientScript);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona a categoria selecionada e a exibe na tela.
        /// </summary>
        /// <returns>
        /// True se a categoria selecionada for encontrada, False caso contrário.
        /// </returns>
        private bool AdicionarCategoria(GridViewCommandEventArgs e)
        {
            int categoriaID = Convert.ToInt32(GridViewManager.GetRowValue(grdCategoria, e, 0));
            categoriaSelecionada = categoriaDB.ObterPorId(categoriaID);

            if (categoriaSelecionada != null)
            {
                lblCategoriaSelecionada.Text = categoriaSelecionada.nome;
                lblCategoriaSelecionada.Visible = true;
                grdCategoria.Visible = false;
            }

            Debug.Write($"categoria Nome: {categoriaSelecionada.nome}\n");
            return categoriaSelecionada != null;
        }

        /// <summary>
        /// Adiciona o vendedor selecionado e o exibe na tela.
        /// </summary>
        /// <returns>
        /// True se o vendedor selecionado for encontrado, False caso contrário.
        /// </returns>
        private bool AdicionarVendedor(GridViewCommandEventArgs e)
        {
            int vendedorID = Convert.ToInt32(GridViewManager.GetRowValue(grdVendedores, e, 0));
            vendedorSelecionado = vendedorDB.ObterPorId(vendedorID);

            if (vendedorSelecionado != null)
            {
                lblVendedorSelecionado.Text = vendedorSelecionado.nomeFantasia;
                lblVendedorSelecionado.Visible = true;
                grdVendedores.Visible = false;
            }

            return vendedorSelecionado != null;
        }

        /// <summary>
        /// Realiza a validação dos dados selecionados e, se corretos, adiciona o produto ao banco de dados e 
        /// redireciona para a página principal dos carrinhos.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                result += ValidationManager.ErroVisible(lblCategoriaSelecionada, lblErroSemCategoria, lblErroCategoriaIndisponivel);
                result += ValidationManager.ErroVisible(lblVendedorSelecionado, lblErroSemVendedor, lblErroVendedorIndisponivel);
                lblErroSemImagem.Visible = imageSavePath == String.Empty;
                result += lblErroSemImagem.Visible ? -1 : 0;
                result += lblStatusImagem.ForeColor == System.Drawing.Color.Blue ? 0 : -1;

                if (result == 0)
                {
                    if (AdicionarProduto())
                    {
                        ValidationManager.ErroVisible(lblCategoriaSelecionada, lblErroSemCategoria, lblErroCategoriaIndisponivel);
                        ValidationManager.ErroVisible(lblVendedorSelecionado, lblErroSemVendedor, lblErroVendedorIndisponivel);
                        lblStatusImagem.Text = String.Empty;

                        Response.Redirect("ProdutoMain.aspx");
                    }
                    else
                    {
                        MessageManager.MessagePopUp("Algo deu errado ao adicionar o produto!", ClientScript);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona um novo produto com os dados fornecidos e a categoria e vendedor selecionados ao banco de dados.
        /// </summary>
        /// <returns>
        /// True se a adição do produto ao banco de dados for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AdicionarProduto()
        {
            Produto produto = new Produto();

            produto.descricao = txtDescricao.Text;
            produto.preco = Convert.ToDecimal(txtPreco.Text, CultureInfo.InvariantCulture);
            string imagemPath = imageSavePath.Replace(Request.PhysicalApplicationPath, "");
            produto.imagem = imagemPath.Replace("\\", "/");
            produto.status = ddlStatusProduto.Text == "Disponível";
            produto.categoria = categoriaSelecionada;
            produto.vendedor = vendedorSelecionado;

            return produtoDB.Adicionar(produto);
        }

        /// <summary>
        /// Realiza o upload de uma imagem selecionada para o servidor.
        /// </summary>
        /// <returns>
        /// 0 se a imagem for lida, -1 caso contrário.
        /// </returns>
        private int UploadImagem()
        {
            string saveDir = @"imagens\";
            string appDir = Request.PhysicalApplicationPath;

            if (fuImagem.HasFile)
            {
                imageSavePath = appDir + saveDir + Server.HtmlDecode(fuImagem.FileName);

                fuImagem.SaveAs(imageSavePath);

                lblStatusImagem.Visible = true;
                lblStatusImagem.ForeColor = System.Drawing.Color.Blue;
                lblStatusImagem.Text = "Imagem salva com sucesso!";

                lblErroSemImagem.Visible = false;

                return 0;
            }
            else
            {
                lblStatusImagem.Visible = true;
                lblStatusImagem.ForeColor = System.Drawing.Color.Red;
                lblStatusImagem.Text = "Não foi possível salvar a imagem";

                lblErroSemImagem.Visible = false;

                return -1;
            }
        }

        /// <summary>
        /// Executa o upload da imagem.
        /// </summary>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadImagem();
        }

        /// <summary>
        /// Redireciona o usuário para a página principal de produtos.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdutoMain.aspx");
        }
    }
}
