//Este arquivo contém os métodos que auxiliam com o gerenciamento de exibição de labels de erro.

using System.Web.UI.WebControls;

namespace Web.WebController
{
    /// <summary>
    /// Classe responsável por implementar os métodos que gerenciam a exibição de labels de erro.
    /// </summary>
    public class ValidationManager
    {
        /// <summary>
        /// Verifica se um rótulo de erro deve ser exibido com base no texto de um rótulo e no estado de visibilidade de um rótulo principal de erro.
        /// </summary>
        /// <param name="label">O rótulo contendo o texto cujo comprimento será verificado.</param>
        /// <param name="erroLabel">O rótulo de erro a ser controlado pela visibilidade.</param>
        /// <param name="masterErroLabel">O rótulo principal de erro cuja visibilidade afetará o rótulo de erro.</param>
        /// <returns>0 se o rótulo de erro não deve ser exibido, -1 se o rótulo de erro deve ser exibido.</returns>
        public static int ErroVisible(Label label, Label erroLabel, Label masterErroLabel)
        {
            if (label.Text.Length > 0 && !masterErroLabel.Visible)
            {
                erroLabel.Visible = false;
                return 0;
            }
            else
            {
                erroLabel.Visible = true;
                return -1;
            }
        }
    }
}