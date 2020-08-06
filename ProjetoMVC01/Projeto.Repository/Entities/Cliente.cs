using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Repository.Entities
{
    public class Cliente
    {
        #region Propriedades

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        #endregion

        #region Construtores

        public Cliente()
        {

        }

        public Cliente(int idCliente, string nome, string email, string cpf, DateTime dataNascimento)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        #endregion

        #region Relacionamentos

        public List<Dependente> Dependentes { get; set; }

        #endregion
    }
}
