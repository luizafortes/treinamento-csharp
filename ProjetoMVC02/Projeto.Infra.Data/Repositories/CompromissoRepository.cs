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
    public class CompromissoRepository : ICompromissoRepository
    {
        //atributo - readonly: somente o construtor pode modificar o valor a variável)
        private readonly string connectionString;

        //construtor para inicializar o atributo connectionString
        public CompromissoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Compromisso entity)
        {
            var query = "insert into Compromisso(Titulo, Descricao, DataInicio, HoraInicio, DataFim, HoraFim, IdUsuario) "
                      + "values(@Titulo, @Descricao, @DataInicio, @HoraInicio, @DataFim, @HoraFim, @IdUsuario)";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Update(Compromisso entity)
        {
            var query = "Update Compromisso set Titulo = @Titulo, Descricao = @Descricao, DataInicio = @DataInicio, " 
                      + "HoraInicio = @HoraInicio, DataFim = @DataFim, HoraFim = @HoraFim, IdUsuario =  @IdUsuario "
                      + "where IdCompromisso = @IdCompromisso";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Delete(Compromisso entity)
        {
            var query = "delete from Compromisso where IdCompromisso = @IdCompromisso ";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Compromisso> GetAll()
        {
            var query = "select * from Compromisso";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Compromisso>(query).ToList(); ;
            }
        }

        public Compromisso GetById(int id)
        {
            var query = "select * from Compromisso where IdUsuario = @IdUsuario";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Compromisso>(query, new { IdCompromisso = id }); ;
            }
        }

        public List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax)
        {
            var query = "select * from Compromisso where DataInicio between @DataMin and @DataMax";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Compromisso>(query, new { DataMin = dataMin, DataMax = dataMax}).ToList(); ;
            }
        }
    }
}
