//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página ProdutoEditar.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using Web.WebController;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página ProdutoEditar.
    /// </summary>
    public partial class ProdutoEditar : System.Web.UI.Page
    {
        private static Categoria categoriaSelecionada;
        private static Vendedor vendedorSelecionado;
        private static Produto produto;
        private static List<Vendedor> listaVendedoresDisponiveis = new List<Vendedor>();
        private static string imageSavePath = String.Empty;
        private VendedorRepository vendedorDB = new VendedorRepository();
        private CategoriaRepository categoriaDB = new CategoriaRepository();
        private ProdutoRepository produtoDB = new ProdutoRepository();

        /// <summary>
        /// Carrega as informações iniciais da página, como o GridView de categorias, 
        /// informações anteriores do produto e dropdown de status, se não for um postback.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridViewManager.CarregarGridView<CategoriaRepository, Categoria>(grdCategoria);
                    lblErroCategoriaIndisponivel.Visible = grdCategoria.Rows.Count == 0;

                    PreencherInformaçõesAnteriores();

                    PreencherDropdownStatus();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Preenche os campos da página com as informações anteriores do produto, como descrição, preço, categoria, vendedor e imagem.
        /// </summary>
        private void PreencherInformaçõesAnteriores()
        {
            int produtoID = Convert.ToInt32(Request.QueryString["parametro1"]);
            produto = produtoDB.ObterPorId(produtoID);

            txtDescricao.Text = produto.descricao;
            txtPreco.Text = produto.preco.ToString();
            lblCategoriaSelecionadaPlaceHolder.Text = produto.categoria.nome;
            lblVendedorSelecionado.Text = produto.vendedor.nomeFantasia;
            imgProduto.ImageUrl = produto.imagem;
        }

        /// <summary>
        /// Preenche o dropdown de status do produto com as opções "Disponível" e "Indisponível".
        /// </summary>
        private void PreencherDropdownStatus()
        {
            string[] listaStatus = { "Disponível", "Indisponível" };
            ddlStatusProduto.DataSource = listaStatus;
            ddlStatusProduto.DataBind();
        }

        /// <summary>
        /// Executa ações com base no comando enviado pelo GridView, como adicionar uma categoria ao produto.
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
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        /// <summary>
        /// Adiciona a categoria selecionada ao produto e exibe-a na tela.
        /// </summary>
        /// <returns>
        /// True se a categoria seleciona for encontrada, False caso contrário
        /// </returns>
        private bool AdicionarCategoria(GridViewCommandEventArgs e)
        {
            int categoriaID = Convert.ToInt32(GridViewManager.GetRowValue(grdCategoria, e, 0));
            categoriaSelecionada = categoriaDB.ObterPorId(categoriaID);
            lblCategoriaSelecionadaPlaceHolder.Visible = false;

            if (categoriaSelecionada != null)
            {
                lblCategoriaSelecionada.Text = categoriaSelecionada.nome;
                lblCategoriaSelecionada.Visible = true;
                grdCategoria.Visible = false;
            }

            return categoriaSelecionada != null;
        }

        /// <summary>
        /// Realiza a validação dos dados selecionados e, se corretos, adiciona o produto ao banco de dados e 
        /// redireciona para a página principal dos produtos.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                result += ValidationManager.ErroVisible(lblCategoriaSelecionada, lblErroSemCategoria, lblErroCategoriaIndisponivel);
                lblErroSemImagem.Visible = produto.imagem == String.Empty;
                result += lblErroSemImagem.Visible ? -1 : 0;

                if (result == 0)
                {
                    if (AtualizarProduto())
                    {
                        ValidationManager.ErroVisible(lblCategoriaSelecionada, lblErroSemCategoria, lblErroCategoriaIndisponivel);
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
        /// Atualiza as informações do produto no banco de dados.
        /// </summary>
        /// <returns>
        /// True se a atualização for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AtualizarProduto()
        {
            produto.descricao = txtDescricao.Text;
            produto.preco = Convert.ToDecimal(txtPreco.Text, CultureInfo.InvariantCulture);
            produto.status = ddlStatusProduto.Text == "Disponível";
            produto.categoria = categoriaSelecionada;
            produto.vendedor = vendedorSelecionado;

            return produtoDB.Atualizar(produto);
        }

        /// <summary>
        /// Realiza o upload da imagem selecionada para o servidor e atualiza o caminho da imagem do produto.
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

                string imagemPath = imageSavePath.Replace(Request.PhysicalApplicationPath, "");
                produto.imagem = imagemPath.Replace("\\", "/");

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
        /// Faz upload da imagem para o servidor.
        /// </summary>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadImagem();
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