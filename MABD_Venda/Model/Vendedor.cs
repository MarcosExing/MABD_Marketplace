// Este arquivo contém a implementação da classe Vendedor.

using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Classe responsável por representar um vendedor e gerenciar suas informações.
    /// </summary>
    public class Vendedor : Pessoa, IEntity
    {
        private string _razaoSocial;
        public string razaoSocial
        {
            get => _razaoSocial;
            set //Só aceita nomes sem dígitos e sem símbolos.
            {
                if (!value.Any(char.IsDigit) && !value.Any(char.IsSymbol))
                {
                    _razaoSocial = value;
                }
                else
                {
                    throw new Exception("Razão Social inválida!");
                }
            }
        }
        public string nomeFantasia { get; set; }
        private string _cnpj;
        public string cnpj
        {
            get => _cnpj;
            set //Só aceita cnpj válido (cnpj com 14 dígitos).
            {
                if (value.All(char.IsNumber) && value.Length == 14)
                {
                    _cnpj = value;
                }
                else
                {
                    throw new Exception("CNPJ inválido!");
                }
            }
        }
        public decimal comissao { get; set; }

        public Vendedor(string email, string senha, Endereco endereco,
            string razaoSocial, string nomeFantasia, string cnpj, decimal comissao)
            : base(email, senha, endereco)
        {
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.cnpj = cnpj;
            this.comissao = comissao;
        }

        public Vendedor() { }
    }
}
