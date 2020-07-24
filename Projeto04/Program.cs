using System;
using System.Dynamic;
using Projeto04.Entities; //importando
using Projeto04.Repositories; //importando

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*** CONTROLE DE FUNCIONARIOS ***\n");

            try
            {
                var funcionario = new Funcionario();

                Console.Write("Nome do Funcionário.........: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Salário do Funcionário.........: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine());

                Console.Write("Data de Admissão do Funcionário.........: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);

                Console.WriteLine("\nFuncionário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //imprimindo mensagem de erro
                Console.WriteLine("Erro: " + e.Message);
            }

            Console.ReadKey(); //pausar a execução
        }
    }
}
