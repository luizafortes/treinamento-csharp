using Projeto05.Abstracts;
using Projeto05.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto05.Repositories
{
    //implementação / sobrescrita de um método abstrato
    public class ClienteRepositoryCsv : ClienteRepositoryAbstract
    {
        public override void Exportar(Cliente cliente)
        {
            CriarDiretorio();

            using (var streamWriter = new StreamWriter(path + "clientes.csv"))
            {
                var csv = $"{cliente.IdCliente};{cliente.Nome};{cliente.Cpf};"
                        + $"{cliente.DataNascimento.ToString("dd/MM/yyyy")};"
                        + $"{cliente.Sexo};{cliente.EstadoCivil}";

                streamWriter.WriteLine("IdCliente;Nome;CPF;DataNascimento;Sexo;EstadoCivil");
                streamWriter.WriteLine(csv);
            }
        }
    }
}
