//Este arquivo contém os métodos que auxiliam com a exibição de mensagens na tela do navegador.

using System;
using System.Web.UI;

namespace Web
{
    /// <summary>
    /// Classe responsável por implementar os métodos que exibem mensagens na tela do navegador.
    /// </summary>
    public class MessageManager
    {
        /// <summary>
        /// Exibe um pop-up de exceção com a mensagem da exceção especificada.
        /// </summary>
        /// <param name="ex">A exceção a ser exibida no pop-up.</param>
        /// <param name="clientScriptManager">O gerenciador de script do cliente.</param>
        public static void ExceptionPopUp(Exception ex, ClientScriptManager clientScriptManager)
        {
            string script = "alert('" + ex.Message.Replace("'", "\\'") + "');";
            clientScriptManager.RegisterStartupScript(clientScriptManager.GetType(), "alert", script, true);
        }

        /// <summary>
        /// Exibe um pop-up de mensagem com a mensagem especificada.
        /// </summary>
        /// <param name="message">A mensagem a ser exibida no pop-up.</param>
        /// <param name="clientScriptManager">O gerenciador de script do cliente.</param>
        public static void MessagePopUp(string message, ClientScriptManager clientScriptManager)
        {
            string script = "alert('" + message + "');";
            clientScriptManager.RegisterStartupScript(clientScriptManager.GetType(), "alert", script, true);
        }
    }
}