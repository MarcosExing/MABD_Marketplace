// Este arquivo contém a classe Cliente, que representa um cliente no sistema e herda as características da classe Pessoa.

using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Classe responsável por modelar um cliente, incluindo propriedades como nome e CPF, e herda as características da classe Pessoa.
    /// </summary>
    public class Cliente : Pessoa, IEntity
    {
        private string _nome;
        public string nome
        {
            get => _nome;
            set //Só aceita nomes sem números e símbolos.
            {
                if (!value.Any(char.IsDigit) && !value.Any(char.IsSymbol))
                {
                    _nome = value;
                }
                else
                {
                    throw new Exception("Nome inválido!");
                }
            }
        }
        private long _cpf;
        public long cpf
        {
            get => _cpf;
            set //Só aceita cpf válido (cpf com 11 dígitos).
            {
                if (value > 9999999999 && value < 100000000000)
                {
                    _cpf = value;
                }
                else
                {
                    throw new Exception("CPF inválido!");
                }
            }
        }

        public Cliente(string email, string senha, Endereco endereco, string nome, long cpf)
            : base(email, senha, endereco)
        {
            this.nome = nome;
            this.cpf = cpf;
        }

        public Cliente() { }
    }
}
