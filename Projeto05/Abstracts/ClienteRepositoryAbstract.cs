using Projeto05.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto05.Abstracts
{
    public abstract class ClienteRepositoryAbstract
    {
        //atributo
        protected string path = "c:\\Users\\luiza\\Documents\\CSharp_CotiInformatica\\temp\\";

        //métodos concretos
        protected void CriarDiretorio()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        //métodos abstratos
        public abstract void Exportar(Cliente cliente);
    }
}
