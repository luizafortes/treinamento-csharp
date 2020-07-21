using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Entities
{
    public class Funcionario : Pessoa
    {
        public DateTime DataAdmissao { get; set; }
        public string Matricula { get; set; }
        public decimal Salario { get; set; }

        public Setor Setor { get; set; }
        public Funcao Funcao { get; set; }
    }
}
