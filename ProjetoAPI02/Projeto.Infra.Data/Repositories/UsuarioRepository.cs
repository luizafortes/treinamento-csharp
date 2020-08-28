using Dapper;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para inicializar a connectionstring
        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Insert(Usuario obj)
        {
            var query = "insert into Usuario(Nome, Email, Senha, DataCriacao) "
                      + "values(@Nome, @Email, @Senha, @DataCriacao)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Update(Usuario obj)
        {
            var query = "update Usuario set Nome = @Nome, Email = @Email, Senha = @Senha "
                      + "where IdUsuario = @IdUsuario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Delete(Usuario obj)
        {
            var query = "delete from Usuario where IdUsuario = @IdUsuario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Usuario> GetAll()
        {
            var query = "select * from Usuario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public Usuario GetById(int id)
        {
            var query = "select * from Usuario where IdUsuario = @IdUsuario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>
                    (query, new { IdUsuario = id });
            }
        }

        public Usuario GetByEmail(string email)
        {
            var query = "select * from Usuario where Email = @Email";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>
                    (query, new { Email = email });
            }
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            var query = "select * from Usuario where Email = @Email and Senha = @Senha";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Usuario>
                    (query, new { Email = email, Senha = senha });
            }
        }
    }
}
