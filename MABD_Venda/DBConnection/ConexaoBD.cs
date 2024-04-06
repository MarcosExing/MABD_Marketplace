// Este arquivo contém a implementação da classe ConexaoBD, que gerencia a conexão com o banco de dados.

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace DBConnection
{
    /// <summary>
    /// Classe responsável pela gestão da conexão com o banco de dados.
    /// </summary>
    public class ConexaoBD
    {
        private static SqlConnection sqlConnection;

        /// <summary>
        /// Configura a conexão com o banco de dados a partir da string de conexão fornecida no arquivo ConexãoConfig.xml.
        /// </summary>
        public static void ConfigurarConexao()
        {
            string dirOrigem = AppDomain.CurrentDomain.BaseDirectory;

            XDocument xmlDoc = XDocument.Load(dirOrigem + "/ConexãoConfig.xml");
            XElement elemento = xmlDoc.Descendants("String1").FirstOrDefault();

            string strConexao = elemento.Value;
            sqlConnection = new SqlConnection(strConexao);
        }

        /// <summary>
        /// Estabelece e abre a conexão com o banco de dados.
        /// </summary>
        /// <returns>Instância de SqlConnection configurada e aberta.</returns>
        public static SqlConnection Conectar()
        {
            ConfigurarConexao();

            sqlConnection.Open();

            return sqlConnection;
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        public static void Fechar()
        {
            sqlConnection.Close();
        }
    }
}
