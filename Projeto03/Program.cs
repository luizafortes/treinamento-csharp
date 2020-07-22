using Projeto03.Contracts;
using Projeto03.Entities;
using Projeto03.Repositories;
using System;
using System.Collections.Generic;

namespace Projeto03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n***CONTROLE DE FORNECEDORES E PRODUTOS***\n");
            try
            {
                //criando uma variável de instância (objeto) para Fornecedor
                var fornecedor = new Fornecedor();

                //inicializando a lista de produtos contida em fornecedor
                fornecedor.Produtos = new List<Produto>();

                Console.Write("Nome do Fornecedor..........: ");
                fornecedor.Nome = Console.ReadLine();

                Console.Write("CNPJ do Fornecedor..........: ");
                fornecedor.Cnpj = Console.ReadLine();

                Console.Write("Quantidade de Produtos......: ");
                var quantidade = int.Parse(Console.ReadLine());

                //laço de repetição -> for + 2x[tab]
                for (int i = 0; i < quantidade; i++)
                {
                    //criando uma variável de instância de produto
                    var produto = new Produto();
                    produto.Id = Guid.NewGuid();

                    //interpolação de string através do '$' antes da string para uso de variável dentro da string
                    Console.Write($"\nInforme o {i+1}º Produto:\n"); 

                    Console.Write("Nome do Produto............: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Preço do Produto...........: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("Quantidade do Produto......: "); 
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    //adicionando o produto à lista contida no fornecedor
                    fornecedor.Produtos.Add(produto);

                    Console.Write("\n*****************************\n");
                }

                //solicitar que o usuário informe 1(JSON) ou 2(XML)
                Console.Write("\nInforme (1)JSON ou (2)XML: ");
                var opcao = int.Parse(Console.ReadLine());

                //Objeto da interface com valor null (vazio)
                IFornecedorRepository fornecedorRepository = null;

                //estrutura de escolha
                switch (opcao)
                {
                    case 1:
                        //POLIMORFISMO
                        fornecedorRepository = new FornecedorRepositoryJSON();
                        break;

                    case 2:
                        //POLIMORFISMO
                        fornecedorRepository = new FornecedorRepositoryXML();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }

                //verificando se o objeto foi inicializado
                if (fornecedorRepository != null)
                {
                    fornecedorRepository.Exportar(fornecedor);

                    //verificar qual instância foi dada para o objeto
                    if (fornecedorRepository is FornecedorRepositoryJSON)
                    {
                        Console.WriteLine("\nArquivo JSON gerado com sucesso.");
                    }
                    else if (fornecedorRepository is FornecedorRepositoryXML)
                    {
                        Console.WriteLine("\nArquivo XML gerado com sucesso.");
                    }
                }

                //imprimindo os dados:
                Console.WriteLine("\nDADOS DO FORNECEDOR\n");

                Console.WriteLine("\tId do Fornecedor............: " + fornecedor.Id);
                Console.WriteLine("\tNome do Fornecedor..........: " + fornecedor.Nome);
                Console.WriteLine("\tCNPJ do Fornecedor..........: " + fornecedor.Cnpj);

                //foreach + 2x[tab]
                //foreach (var item in collection){} 
                //item é cada objeto contido na lista
                //collection é a lista a ser percorrida
                foreach (var item in fornecedor.Produtos) 
                {
                    Console.WriteLine("\t----");
                    Console.WriteLine("\tId do Produto...............: " + item.Id);
                    Console.WriteLine("\tNome do Produto.............: " + item.Nome);
                    Console.WriteLine("\tPreço do Produto............: " + item.Preco);
                    Console.WriteLine("\tQuantidade do Produto.......: " + item.Quantidade);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
