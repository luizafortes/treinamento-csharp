using Projeto03.Contracts;
using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryXML : IFornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            var filename = $"fornecedor_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml";

            //abrindo um arquivo XML em modo de escrita
            using (var streamWriter = new StreamWriter("c:\\temp\\" + filename))
            {
                //serializar os dados do fornecedor para XML
                var xml = new XmlSerializer(fornecedor.GetType());
                //gravando oos dados do XML no arquivo
                xml.Serialize(streamWriter, fornecedor);
            }
        }
    }
}
