using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Dapper;

using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo - readonly: somente o construtor pode modificar o valor a variável)
        private readonly string connectionString;

        //construtor para inicializar o atributo connectionString
        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Usuario entity)
        {
            var query = "insert into Usuario(Nome, Email, Senha, DataCriacao) "
                      + "values(@Nome, @Email, @Senha, @DataCriacao)";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Update(Usuario entity)
        {
            var query = "update Usuario set Nome = @Nome, Email = @Email, Senha = @Senha "
                      + "where IdUsuario = @IdUsuario";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Delete(Usuario entity)
        {
            var query = "delete from Usuario where IdUsuario = @IdUsuario ";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Usuario> GetAll()
        {
            var query = "select * from Usuario";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query).ToList(); ;
            }
        }

        public Usuario GetById(int id)
        {
            var query = "select * from Usuario where IdUsuario = @IdUsuario";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>(query, new { IdUsuario = id }); ;
            }
        }

        public Usuario GetByEmail(string email)
        {
            var query = "select * from Usuario where Email = @Email";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>(query, new { Email = email }); ;
            }
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            var query = "select * from Usuario where Email = @Email and Senha = @Senha";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>(query, new { Email = email, Senha = senha }); ;
            }
        }
    }
}
