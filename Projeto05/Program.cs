using Projeto05.Abstracts;
using Projeto05.Entities;
using Projeto05.Enums;
using Projeto05.Repositories;
using System;

namespace Projeto05
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Luiza Fortes",
                "104.225.347-14",
                new DateTime(1984,03,12),
                Sexo.Feminino,
                EstadoCivil.Solteiro
                );

            Console.WriteLine("\nDados do Cliente:");
            Console.WriteLine("Id.........: " + cliente.IdCliente);
            Console.WriteLine("Nome.......: " + cliente.Nome);
            Console.WriteLine("Cpf........: " + cliente.Cpf);
            Console.WriteLine("Data Nasc..: " + cliente.DataNascimento.ToString("dd/MM/yyyy"));
            Console.WriteLine("Sexo.......: " + cliente.Sexo);
            Console.WriteLine("Est Civil..: " + cliente.EstadoCivil);

            try
            {
                //criando uma variável para a classe abstrata

                ClienteRepositoryAbstract clienteRepository = null;

                Console.Write("\nInforme (1)TXT ou (2)CSV....:");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        //POLIMORFISMO
                        clienteRepository = new ClienteRepositoryTxt();
                        break;

                    case 2:
                        //POLIMORFISMO
                        clienteRepository = new ClienteRepositoryCsv();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }

                if (clienteRepository != null)
                {
                    clienteRepository.Exportar(cliente);
                    Console.WriteLine("\nDados gravados com sucesso!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                Console.WriteLine("\nFim do Programa!");
            }

            Console.ReadKey();
        }
    }
}
