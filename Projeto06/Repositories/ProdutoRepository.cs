using Projeto06.Abstracts;
using Projeto06.Entities;
using Projeto06.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto06.Repositories
{
    public class ProdutoRepository : ProdutoRepositoryAbstract
    {
        public override void Create(Produto produto)
        {
            //para adicionar um produto na lista, preciso verificar
            //atraves do id do produto, se ele ja foi adicionado

            //verificar se ja existe na lista um produto
            //com o mesmo id informado no método
            var qtd = produtos.Count(p => p.IdProduto == produto.IdProduto);

            if (qtd == 0) //não existe
            {
                produtos.Add(produto); //adicionando na lista
            }
            else
            {
                //lançar uma exceção
                throw new Exception("O produto já existe!");
            }
        }

        public override void Update(Produto produto)
        {
            //procurar um produto dentro da lista pelo id
            var registro = produtos.FirstOrDefault(p => p.IdProduto == produto.IdProduto);

            //verificar se o registro foi encontrado..
            if (registro != null)
            {
                //alterando os dados do registro
                registro.Nome = produto.Nome;
                registro.Preco = produto.Preco;
                registro.Status = produto.Status;
            }
            else
            {
                throw new Exception("Produto não encontrado!");
            }
        }

        public override void Delete(Produto produto)
        {
            //procurar um produto dentro da lista pelo id
            var registro = produtos.FirstOrDefault(p => p.IdProduto == produto.IdProduto);

            //verificar se o registro foi encontrado..
            if (registro != null)
            {
                produtos.Remove(registro); //excluindo o produto
            }
            else
            {
                throw new Exception("Produto não encontrado!");
            }
        }

        public override List<Produto> GetAll()
        {
            return produtos
                    .OrderBy(p => p.IdProduto)
                    .ToList();
        }

        public override List<Produto> GetByNome(string nome)
        {
            return produtos
                    .Where(p => p.Nome.Contains(nome))
                    .OrderBy(p => p.IdProduto)
                    .ToList();
        }

        public override List<Produto> GetByPreco(decimal precoMin, decimal precoMax)
        {
            return produtos
                    .Where(p => p.Preco >= precoMin && p.Preco <= precoMax)
                    .OrderBy(p => p.IdProduto)
                    .ToList();
        }

        public override List<Produto> GetByStatus(Status status)
        {
            return produtos
                    .Where(p => p.Status == status)
                    .OrderBy(p => p.IdProduto)
                    .ToList();
        }

        public override Produto GetById(int id)
        {
            return produtos.FirstOrDefault(p => p.IdProduto == id);
        }
    }
}
