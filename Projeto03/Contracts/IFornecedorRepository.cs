using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto03.Contracts
{
    public interface IFornecedorRepository
    {
        //métodos abstratos
        void Exportar(Fornecedor fornecedor);
    }
}
