using Projeto05.Abstracts;
using Projeto05.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto05.Repositories
{
    public class ClienteRepositoryTxt : ClienteRepositoryAbstract
    {
        //implementação / sobrescrita de um método abstrato
        public override void Exportar(Cliente cliente)
        {
            CriarDiretorio();

            using (var streamWriter = new StreamWriter(path + "clientes.txt", true))
            {
                streamWriter.WriteLine("Id...............: " + cliente.IdCliente);
                streamWriter.WriteLine("Nome.............: " + cliente.Nome);
                streamWriter.WriteLine("Cpf..............: " + cliente.Cpf);
                streamWriter.WriteLine("Data Nascimento..: " + cliente.DataNascimento.ToString("dd/MM/yyyy"));
                streamWriter.WriteLine("Sexo.............: " + cliente.Sexo);
                streamWriter.WriteLine("Estado Civil.....: " + cliente.EstadoCivil);
                streamWriter.WriteLine("---");

            }
        }
    }
}
