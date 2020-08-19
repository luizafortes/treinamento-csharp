using Projeto.Infra.Data.Dtos;
using Projeto.Infra.Data.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
    public interface ICompromissoRepository : IBaseRepository<Compromisso>
    {
        List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, int idUsuario);
        List<ResumoCategoriaDto> GetResumoCategoria(int idUsuario);
    }
}