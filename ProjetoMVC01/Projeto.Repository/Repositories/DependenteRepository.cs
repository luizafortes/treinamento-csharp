using Dapper;
using Projeto.Repository.Contracts;
using Projeto.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Repository.Repositories
{
    public class DependenteRepository : IDependenteRepository
    {
        private readonly string connectionString;

        public DependenteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Dependente entity)
        {
            var query = "insert into Dependente(Nome, DataNascimento, IdCliente) "
                      + "values(@Nome, @DataNascimento, @IdCliente)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Update(Dependente entity)
        {
            var query = "update Dependente set Nome = @Nome, DataNascimento = @DataNascimento = @IdCliente "
                      + "where IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Delete(Dependente entity)
        {
            var query = "delete from Dependente where IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Dependente> GetAll()
        {
            var query = "select * from Dependente";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Dependente>(query).ToList();
            }
        }

        public Dependente GetById(int id)
        {
            var query = "select * from Dependente where IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Dependente>
                    (query, new { IdDependente = id });
            }
        }
    }
}
