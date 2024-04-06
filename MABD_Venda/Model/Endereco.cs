// Este arquivo contém a classe Endereco, que representa um endereço no sistema.

using System;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Classe responsável por representar um endereço.
    /// </summary>
    public class Endereco : IEntity
    {
        public int id { get; set; }
        private string _cep;
        public string cep
        {
            get => _cep;
            set
            {
                if (value.All(char.IsDigit) && value.Length == 8)
                {
                    _cep = value;
                }
                else
                {
                    throw new Exception("Cep inválido!");
                }
            }
        }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }


        public Endereco(string cep, string cidade, string estado, string rua, string bairro)
        {
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
            this.rua = rua;
            this.bairro = bairro;
        }

        public Endereco() { }
    }
}
