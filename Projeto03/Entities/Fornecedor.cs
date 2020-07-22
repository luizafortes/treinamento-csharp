using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto03.Entities
{
    public class Fornecedor
    {
        //prop + 2x[tab]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        //Relacionamento de Associação
        //Multiplicidade TER-MUITOS
        public List<Produto> Produtos { get; set; }
    }
}
