//Este arquivo contém a implementação dos métodos responsáveis por realizar as ações da página CategoriaAdicionar.

using DAL;
using Model;
using System;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos responsáveis pelas ações da página CategoriaAdicionar.
    /// </summary>
    public partial class CategoriaAdicionar : System.Web.UI.Page
    {
        private static CategoriaRepository categoriaDB = new CategoriaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Adiciona uma nova categoria ao banco de dados e redireciona para a página principal de categorias se a operação for bem-sucedida.
        /// Caso contrário, exibe uma mensagem de erro.
        /// </summary>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (AdicionarCategoria())
            {
                Response.Redirect("CategoriaMain.aspx");
            }
            else
            {
                MessageManager.MessagePopUp("Não foi possível adicionar a categoria!", ClientScript);
            }
        }

        /// <summary>
        /// Adiciona uma categoria com o nome fornecido ao banco de dados.
        /// </summary>
        /// <returns>
        /// True se a adição da categoria ao banco for bem-sucedida, False caso contrário.
        /// </returns>
        private bool AdicionarCategoria()
        {
            Categoria categoria = new Categoria(txtNome.Text);

            return categoriaDB.Adicionar(categoria);
        }

        /// <summary>
        /// Redireciona o usuário para a página principal das categorias.
        /// </summary>
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaMain.aspx");
        }
    }
}