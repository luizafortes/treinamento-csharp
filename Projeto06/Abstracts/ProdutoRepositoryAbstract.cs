using Projeto06.Entities;
using Projeto06.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto06.Abstracts
{
    public abstract class ProdutoRepositoryAbstract
    {
        #region Atributos
        protected readonly List<Produto> produtos;
        #endregion

        #region Construtores
        public ProdutoRepositoryAbstract()
        {
            produtos = new List<Produto>();
        }
        #endregion

        #region Métodos Abstratos
        public abstract void Create(Produto produto);
        public abstract void Update(Produto produto);
        public abstract void Delete(Produto produto);
        public abstract List<Produto> GetAll();
        public abstract List<Produto> GetByNome(string nome);
        public abstract List<Produto> GetByPreco(decimal precoMin, decimal precoMax);
        public abstract List<Produto> GetByStatus(Status status);
        public abstract Produto GetById(int id);
        #endregion

    }
}
