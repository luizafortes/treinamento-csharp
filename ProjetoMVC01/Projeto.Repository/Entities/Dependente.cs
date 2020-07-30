using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Repository.Entities
{
    public class Dependente
    {
        #region Propriedades

        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdCliente { get; set; }

        #endregion

        #region Construtores

        public Dependente()
        {

        }

        public Dependente(int idDependente, string nome, DateTime dataNascimento, int idCliente)
        {
            IdDependente = idDependente;
            Nome = nome;
            DataNascimento = dataNascimento;
            IdCliente = idCliente;
        }

        #endregion

        #region Relacionamentos

        public Cliente Cliente { get; set; }

        #endregion
    }
}
