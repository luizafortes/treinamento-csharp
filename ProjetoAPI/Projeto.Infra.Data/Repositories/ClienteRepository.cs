using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Dapper;

using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //atributo para armazenar a connectionstring
        private readonly string connectionString;

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Insert(Cliente entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_InserirCliente",
                    new
                    {
                        Nome = entity.Nome,
                        Cpf = entity.Cpf,
                        Email = entity.Email
                    },
                    commandType : CommandType.StoredProcedure);
            }
        }

        public void Update(Cliente entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_AlterarCliente",
                    new
                    {
                        IdCliente = entity.IdCliente,
                        Nome = entity.Nome,
                        Cpf = entity.Cpf,
                        Email = entity.Email
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Cliente entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_ExcluirCliente",
                    new
                    {
                        IdCliente = entity.IdCliente
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Cliente> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(
                    "SP_ConsultarCliente",
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public Cliente GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Cliente>(
                    "SP_ObterClientePorId",
                    new
                    {
                        IdCliente = id
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Cliente GetByCpf(string cpf)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Cliente>(
                    "SP_ObterClientePorCpf",
                    new
                    {
                        Cpf = cpf
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Cliente GetByEmail(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Cliente>(
                    "SP_ObterClientePorEmail",
                    new
                    {
                        Email = email
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
