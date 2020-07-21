using System;
using Projeto02.Entities; //importando
using Projeto02.Utils;
using Projeto02.Repositories;

namespace Projeto02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n *** EXPORTADOR DE FUNCIONÁRIOS *** \n");

            try
            {
                var funcionario = new Funcionario();
                funcionario.Setor = new Setor(); //cria uma instância da classe Setor dentro a instância funcionario
                funcionario.Funcao = new Funcao(); //cria uma instância da classe Função dentro a instância funcionario

                funcionario.Id = Guid.NewGuid(); //herdado de Pessoa
                funcionario.Nome = ConsoleUtil.ReadString("Nome do Funcionário: "); //herdado de Pessoa
                funcionario.Cpf = ConsoleUtil.ReadString("CPF: "); //herdado de Pessoa
                funcionario.Matricula = ConsoleUtil.ReadString("Matrícula: ");
                funcionario.DataAdmissao = ConsoleUtil.ReadDateTime("Data de Admissão: ");
                funcionario.Salario = ConsoleUtil.ReadDecimal("Salário: ");

                funcionario.Setor.Id = Guid.NewGuid();
                funcionario.Setor.Nome = ConsoleUtil.ReadString("Nome do Setor: ");
                funcionario.Setor.Sigla = ConsoleUtil.ReadString("Sigla: ");

                funcionario.Funcao.Id = Guid.NewGuid();
                funcionario.Funcao.Descricao = ConsoleUtil.ReadString("Descrição da Função: ");

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Exportar(funcionario);

                Console.WriteLine("\nFuncionário gravado em JSON com sucesso!");
                
                //importando o funcionário
                var registro = funcionarioRepository.Importar();

                Console.WriteLine("Id do Funcionario.: " + registro.Id);
                Console.WriteLine("Nome..............: " + registro.Nome);
                Console.WriteLine("Matrícula.........: " + registro.Matricula);
                Console.WriteLine("CPF...............: " + registro.Cpf);
                Console.WriteLine("Salário...........: " + registro.Salario);
                Console.WriteLine("Data de Admissão..: " + registro.DataAdmissao);

                Console.WriteLine("Id do Setor.......: " + registro.Setor.Id);
                Console.WriteLine("Sigla do Setor....: " + registro.Setor.Sigla);
                Console.WriteLine("Nome do Setor.....: " + registro.Setor.Nome);

                Console.WriteLine("Id da Função......: " + registro.Funcao.Id);
                Console.WriteLine("Descrição.........: " + registro.Funcao.Descricao);

            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            } 

            Console.ReadKey();
        }
    }
}
