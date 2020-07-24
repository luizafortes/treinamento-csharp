using Dapper;
using Projeto04.Contracts;
using Projeto04.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto04.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //atributo
        private const string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAula04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Funcionario entity)
        {
            //escrevendo uma query SQL para inserir um registro de funcionario
            var query = "insert into Funcionario(Nome, Salario, DataAdmissao)"
                      + "values(@Nome, @Salario, @DataAdmissao)";
            using (var connection = new SqlConnection(connectionstring))
            {
                //executando a query e passar os dados do funcionario
                connection.Execute(query, entity);
            }
        }

        public void Update(Funcionario entity)
        {
            //escrevendo uma query SQL para atualizar um registro de funcionario
            var query = "update Funcionario "
                      + "set Nome = @Nome, Salario = @Salario, DataAdmissao = @DataAdmissao "
                      + "where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, entity);
            }
        }

        public void Delete(Funcionario entity)
        {
            //escrevendo uma query SQL para deletar um registro de funcionario
            var query = "delete Funcionario "
                      + "where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Funcionario> GetAll()
        {
            var query = "select * from Funcionario";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public Funcionario GetById(int id)
        {
            var query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.QueryFirstOrDefault<Funcionario>
                    (query, new { IdFuncionario = id });
            }
        }
    }
}
