using System;
using System.Collections.Generic;
using System.Text;

//localização da classe dentro do projeto
namespace Projeto01.Entities
{
    //definição da classe
    public class Produto
    {
        //digitar prop + 2x[tab]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}