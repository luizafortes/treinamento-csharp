using System;
using System.Collections.Generic;
using System.Text;

using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByCpf(string cpf );
        Cliente GetByEmail(string email);
    }
}
