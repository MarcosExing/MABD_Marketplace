//Este arquivo contém os métodos responsáveis por auxiliam com a manipulação de GridViews.

using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.WebController
{
    /// <summary>
    /// Classe responsável por implementar os métodos que auxiliaram na manipulação dos GridViews.
    /// </summary>
    public class GridViewManager
    {
        /// <summary>
        /// Carrega os dados de uma entidade em um GridView.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório a ser utilizado.</typeparam>
        /// <typeparam name="TEntity">O tipo da entidade a ser carregada.</typeparam>
        /// <param name="gridView">O GridView onde os dados serão exibidos.</param>
        /// <remarks>
        /// Utiliza um repositório genérico para obter todos os registros da entidade e os atribui ao GridView.
        /// </remarks>
        public static void CarregarGridView<TRepository, TEntity>(GridView gridView)
            where TRepository : IRepository<TEntity>, new()
            where TEntity : IEntity, new()
        {

            TRepository repository = new TRepository();
            List<TEntity> lista = repository.ObterTodos();

            gridView.DataSource = lista;
            gridView.DataBind();
        }

        /// <summary>
        /// Obtém o valor de uma célula específica em uma linha de um GridView.
        /// </summary>
        /// <param name="gridView">O GridView que contém a linha.</param>
        /// <param name="e">Os argumentos do comando de GridView.</param>
        /// <param name="numeroColuna">O número da coluna da célula desejada.</param>
        /// <returns>O valor da célula especificada.</returns>
        public static string GetRowValue(GridView gridView, GridViewCommandEventArgs e, int numeroColuna)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            TableCell cellId = gridView.Rows[rowIndex].Cells[numeroColuna];

            return cellId.Text;
        }

        /// <summary>
        /// Obtém o objeto de um controle específico em uma linha de um GridView.
        /// </summary>
        /// <param name="gridView">O GridView que contém a linha.</param>
        /// <param name="e">Os argumentos do comando de GridView.</param>
        /// <param name="numeroColuna">O número da coluna onde está localizado o controle.</param>
        /// <param name="objetoNome">O nome do controle a ser encontrado.</param>
        /// <returns>O objeto do controle especificado.</returns>
        public static object GetRowObject(GridView gridView, GridViewCommandEventArgs e, int numeroColuna, string objetoNome)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            object objeto = gridView.Rows[rowIndex].Cells[5].FindControl(objetoNome);

            return objeto;
        }
    }
}