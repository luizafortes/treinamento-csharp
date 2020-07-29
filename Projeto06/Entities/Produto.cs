using Projeto06.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto06.Entities
{
    public class Produto
    {
        #region Propriedades
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Status Status { get; set; }
        #endregion

        #region Construtores
        public Produto()
        {

        }

        public Produto(int idProduto, string nome, decimal preco, Status status)
        {
            IdProduto = idProduto;
            Nome = nome;
            Preco = preco;
            Status = status;
        }
        #endregion
    }
}
