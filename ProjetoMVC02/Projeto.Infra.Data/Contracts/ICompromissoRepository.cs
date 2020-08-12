using System;
using System.Collections.Generic;
using System.Text;

using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Contracts
{
    public interface ICompromissoRepository : IBaseRepository<Compromisso>
    {
        List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax);
    }
}
