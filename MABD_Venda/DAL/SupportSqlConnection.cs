// Este arquivo contém a implementação da classe SupportSqlConnection, que fornece métodos auxiliares para interação com o banco de dados.

using DBConnection;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Classe responsável por oferecer métodos auxiliares para interação com o banco de dados.
    /// </summary>
    internal class SupportSqlConnection
    {
        /// <summary>
        /// Executa um SqlCommand e verifica se a operação foi bem-sucedida com base no número de linhas afetadas.
        /// </summary>
        /// <param name="cmd">O SqlCommand a ser executado.</param>
        /// <returns>True se a execução for bem-sucedida (linhas afetadas > 0), False caso contrário.</returns>
        public static bool VericarCmd(SqlCommand cmd)
        {
            if (cmd.ExecuteNonQuery() > 0)
            {
                ConexaoBD.Fechar();
                return true;
            }

            ConexaoBD.Fechar();

            return false;
        }

        /// <summary>
        /// Obtém o último ID inserido em uma tabela específica do banco de dados.
        /// </summary>
        /// <param name="tabela">O nome da tabela para a qual se deseja obter o último ID.</param>
        /// <returns>O último ID inserido na tabela especificada.</returns>
        public static int ObterUltimoId(string tabela)
        {
            string queryID = $"SELECT IDENT_CURRENT('{tabela}')";

            SqlCommand cmdID = new SqlCommand(queryID, ConexaoBD.Conectar());
            return Convert.ToInt32(cmdID.ExecuteScalar());
        }

        /// <summary>
        /// Obtém uma lista de entidades dependentes de um determinado ID, utilizando uma consulta específica.
        /// </summary>
        /// <typeparam name="TRepository">O tipo de repositório que implementa a interface IRepository para a entidade.</typeparam>
        /// <typeparam name="TEntity">O tipo da entidade a ser obtida.</typeparam>
        /// <param name="id">O ID para o qual se deseja obter as entidades dependentes.</param>
        /// <param name="query">A consulta SQL para recuperar os IDs das entidades dependentes.</param>
        /// <param name="parametro">O parâmetro da consulta que corresponde ao ID.</param>
        /// <returns>Uma lista das entidades dependentes associadas ao ID fornecido.</returns>
        public static List<TEntity> ObterDependentes<TRepository, TEntity>(int id, string query, string parametro)
            where TRepository : IRepository<TEntity>, new()
            where TEntity : IEntity, new()
        {
            int idEntidade = 0;
            List<TEntity> listaEntidade = new List<TEntity>();
            TRepository repository = new TRepository();

            SqlCommand cmd = new SqlCommand(query, ConexaoBD.Conectar());

            cmd.Parameters.AddWithValue(parametro, id);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    idEntidade = Convert.ToInt32(reader["ID"]);
                    listaEntidade.Add(idEntidade > 0 ? repository.ObterPorId(idEntidade) : default);
                }
            }

            ConexaoBD.Fechar();

            return listaEntidade;
        }
    }
}
