using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }

        //construtor default -> ctor + 2x[tab]
        public Cliente()
        {

        }

        //construtor com entrada de argumentos (Sobrecarga de métodos - OVERLOADING)
        public Cliente(int idCliente, string nome, string cpf, string email, DateTime dataCriacao)
        {
            IdCliente = idCliente;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataCriacao = dataCriacao;
        }
    }
}
