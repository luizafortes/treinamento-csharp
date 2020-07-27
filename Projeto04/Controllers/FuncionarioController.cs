using Projeto04.Contracts;
using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto04.Controllers
{
    public class FuncionarioController
    {
        //atributo
        private IFuncionarioRepository funcionarioRepository;

        //construtor -> ctor + 2x[tab]
        public FuncionarioController()
        {
            //inicializando o atributo
            funcionarioRepository = new FuncionarioRepository();
        }

        //método para cadastrar um funcionário
        public void CadastrarFuncionario()
        {
            var funcionario = new Funcionario();

            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONÁRIO:\n");

                Console.Write("Nome do Funcionário..............: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Salário..........................: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine());

                Console.Write("Data de Admissão.................: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                funcionarioRepository.Create(funcionario);

                Console.WriteLine("\nFuncionário cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para atualizar um funcionário
        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE FUNCIONÁRIO:\n");

                Console.Write("Informe o Id do Funcionário.......: ");
                var idFuncionario = int.Parse(Console.ReadLine());

                //consultar o funcionário no banco de dados atraves do id..
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //verificar se o funcionário foi encontrado
                if (funcionario != null)
                {
                    Console.Write("Altere o Nome do Funcionário......: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("Altere o Salário..................: ");
                    funcionario.Salario = decimal.Parse(Console.ReadLine());

                    Console.Write("Altere a Data de Admissão.........: ");
                    funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                    funcionarioRepository.Update(funcionario);
                    Console.WriteLine("\nFuncionário atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para excluir um funcionário
        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE FUNCIONÁRIO:\n");

                Console.Write("Informe o Id do Funcionário.......: ");
                var idFuncionario = int.Parse(Console.ReadLine());

                //consultar o funcionário no banco de dados atraves do id..
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //verificar se o funcionário foi encontrado
                if (funcionario != null)
                {
                    funcionarioRepository.Delete(funcionario);
                    Console.WriteLine("\nFuncionário excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para consultar todos os funcionários
        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONÁRIO:\n");

                var funcionarios = funcionarioRepository.GetAll();

                //imprimindo os funcionários
                foreach (var item in funcionarios)
                {
                    Console.WriteLine("Id do Funcionário.......: " + item.IdFuncionario);
                    Console.WriteLine("Nome do Funcionário.....: " + item.Nome);
                    Console.WriteLine("Salário.................: " + item.Salario.ToString("c"));
                    Console.WriteLine("Data de Admissão........: " + item.DataAdmissao.ToString("dd/MM/yyyy"));
                    Console.WriteLine("----");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }
    }
}