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
    public class DependenteRepository : IDependenteRepository
    {
        //atributo
        private const string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAula04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Dependente entity)
        {
            var query = "insert into Dependente(Nome, DataNascimento, IdFuncionario)"
                      + "values(@Nome, @DataNascimento, @IdFuncionario)";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, entity);
            }
        }

        public void Update(Dependente entity)
        {
            var query = "update Dependente "
                      + "set Nome = @Nome, DataNascimento = @DataNascimento, IdFuncionario = @IdFuncionario "
                      + "where IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, entity);
            }
        }

        public void Delete(Dependente entity)
        {
            var query = "delete from Dependente where IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(query, entity.IdDependente);
            }
        }

        public List<Dependente> GetAll()
        {
            var query = "select * from Dependente";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Dependente>(query).ToList();
            }
        }

        public Dependente GetById(int id)
        {
            var query = "select * from Dependente where IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.QueryFirstOrDefault<Dependente>(query, new { IdDependente = id });
            }
        }
    }
}
