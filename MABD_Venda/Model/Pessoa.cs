// Este arquivo contém a implementação da classe Pessoa, que é uma classe comum entre Cliente e Vendedor.

using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Classe responsável por implementar a entidade Pessoa que sera classe pai de Cliente e Vendedor.
    /// </summary>
    public class Pessoa : IEntity
    {
        public int id { get; set; }
        private string _email;
        public string email
        {
            get => _email;
            set //Só aceita e-mail válido
            {
                if (new[] { "@", ".com" }.All(s => value.Contains(s)))
                {
                    _email = value;
                }
                else
                {
                    throw new Exception("Email inválido!");
                }
            }
        }
        private string _senha;
        public string senha
        {
            get => _senha;
            set //Só aceita senhas que contenham letras maiúsculas, minúsculas e número.
            {
                if (value.Any(char.IsLetter) && value.Any(char.IsUpper) && value.Any(char.IsLower) && value.Any(char.IsNumber))
                {
                    _senha = value;
                }
                else
                {
                    throw new Exception("Senha inválida!");
                }
            }
        }
        public Endereco endereco { get; set; }

        public Pessoa(string email, string senha, Endereco endereco)
        {
            this.email = email;
            this.senha = senha;
            this.endereco = endereco;
        }

        public Pessoa() { }
    }
}
