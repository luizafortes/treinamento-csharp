using Projeto05.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto05.Entities
{
    public class Cliente
    {
        //prop + 2x[tab]
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        //ctor + 2x[tab]
        public Cliente()
        {
            //construtor default (vazio)
        }

        //sobrecarga de construtor (overloading)
        //recebendo como parametros
        public Cliente(Guid idCliente, string nome, string cpf, DateTime dataNascimento, Sexo sexo, EstadoCivil estadoCivil)
        {
            IdCliente = idCliente;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }
    }
}
