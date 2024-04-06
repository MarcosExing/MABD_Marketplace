using DAL;
using Model;
using System;

namespace Web
{
    public partial class CategoriaEditar : System.Web.UI.Page
    {
        private static Categoria categoria;
        private static CategoriaRepository categoriaDB = new CategoriaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PreencherInformaçõesAnteriores();
                }
            }
            catch (Exception ex)
            {
                MessageManager.ExceptionPopUp(ex, ClientScript);
            }
        }

        private void PreencherInformaçõesAnteriores()
        {
            int categoriaID = Convert.ToInt32(Request.QueryString["parametro1"]);
            categoria = categoriaDB.ObterPorId(categoriaID);

            txtNome.Text = categoria.nome;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (AtualizarCategoria())
            {
                Response.Redirect("CategoriaMain.aspx");
            }
            else
            {
                MessageManager.MessagePopUp("Não foi possível atualizar a categoria!", ClientScript);
            }
        }

        private bool AtualizarCategoria()
        {
            categoria.nome = txtNome.Text;

            return categoriaDB.Atualizar(categoria);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaMain.aspx");
        }
    }
}