using Projeto06.Controllers;
using Projeto06.Entities;
using System;

namespace Projeto06
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoController = new ProdutoController();
            Executar(produtoController);
        }

        static void Executar(ProdutoController produtoController)
        {
            Console.WriteLine("\n*** CONTROLE DE PRODUTOS ***\n");

            try
            {
                Console.WriteLine("(1) - Cadastrar Produto");
                Console.WriteLine("(2) - Atualizar Produto");
                Console.WriteLine("(3) - Excluir Produto");
                Console.WriteLine("(4) - Consultar Produtos");

                Console.Write("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        produtoController.CadastrarProduto();
                        break;

                    case 2:
                        produtoController.AtualizarProduto();
                        break;

                    case 3:
                        produtoController.ExcluirProduto();
                        break;

                    case 4:
                        produtoController.ConsultarProdutos();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
            finally
            {
                Console.Write("\nDeseja realizar outra operação? (S,N): ");
                var opcao = Console.ReadLine().ToUpper();

                if (opcao.Equals("S"))
                {
                    //recursividade..
                    Console.Clear(); //limpar o console..
                    Executar(produtoController);
                }
                else
                {
                    Console.WriteLine("\nFim do Programa!");
                    Console.ReadKey();
                }
            }
        }
    }
}