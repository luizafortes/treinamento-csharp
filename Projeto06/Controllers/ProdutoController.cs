using Projeto06.Entities;
using Projeto06.Enums;
using Projeto06.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto06.Controllers
{
    public class ProdutoController
    {
        //atributo
        private readonly ProdutoRepository produtoRepository;

        //construtor
        public ProdutoController()
        {
            produtoRepository = new ProdutoRepository();
        }

        //método para cadastrar um produto
        public void CadastrarProduto()
        {
            Console.WriteLine("\nCADASTRO DE PRODUTO\n");

            try
            {
                var produto = new Produto();

                Console.Write("Informe o Id do Produto......: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                Console.Write("Informe o Nome do Produto....: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o Preço do Produto...: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o Status do Produto..: ");
                var status = int.Parse(Console.ReadLine());

                switch (status)
                {
                    case 0:
                        produto.Status = Status.Esgotado;
                        break;
                    case 1:
                        produto.Status = Status.Disponivel;
                        break;
                    default:
                        throw new Exception("Status inválido.");
                }

                produtoRepository.Create(produto);

                Console.WriteLine("\nProduto cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        //método para atualizar um produto
        public void AtualizarProduto()
        {
            Console.WriteLine("\nATUALIZAÇÃO DE PRODUTO\n");

            try
            {
                var produto = new Produto();

                Console.Write("Informe o Id do Produto......: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                Console.Write("Informe o Nome do Produto....: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o Preço do Produto...: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o Status do Produto..: ");
                var status = int.Parse(Console.ReadLine());

                switch (status)
                {
                    case 0:
                        produto.Status = Status.Esgotado;
                        break;
                    case 1:
                        produto.Status = Status.Disponivel;
                        break;
                    default:
                        throw new Exception("Status inválido.");
                }

                produtoRepository.Update(produto);

                Console.WriteLine("\nProduto atualizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        //método para excluir um produto
        public void ExcluirProduto()
        {
            Console.WriteLine("\nEXCLUSÃO DE PRODUTO\n");

            try
            {
                var produto = new Produto();

                Console.Write("Informe o Id do Produto......: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                produtoRepository.Delete(produto);

                Console.WriteLine("\nProduto excluído com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        //método para consultar todos os produtos
        public void ConsultarProdutos()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTOS\n");

            try
            {
                foreach (var item in produtoRepository.GetAll())
                {
                    Console.WriteLine("Id do Produto......: " + item.IdProduto);
                    Console.WriteLine("Nome do Produto....: " + item.Nome);
                    Console.WriteLine("Preço..............: " + item.Preco);
                    Console.WriteLine("Status.............: " + item.Status);
                    Console.WriteLine("---");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}