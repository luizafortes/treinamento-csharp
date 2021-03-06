﻿using Projeto.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Repository.Contracts
{
    public interface IDependenteRepository : IBaseRepository<Dependente>
    {
        List<Dependente> GetByNome(string nome);
    }
}
