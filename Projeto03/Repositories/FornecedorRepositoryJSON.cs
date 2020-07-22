using Newtonsoft.Json;
using Projeto03.Contracts;
using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryJSON : IFornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            //criando um nome de arquivo..
            var filename = $"fornecedor_{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

            using (var streamWriter = new StreamWriter("c:\\temp\\" + filename))
            {
                //serializando os dados do forecedor para formato JSON
                var json = JsonConvert.SerializeObject(fornecedor, Formatting.Indented);
                streamWriter.WriteLine(json);
            }
        }
    }
}
