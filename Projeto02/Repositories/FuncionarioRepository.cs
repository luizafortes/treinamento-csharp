using Projeto02.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO; //input e output de arquivos
using Newtonsoft.Json;

namespace Projeto02.Repositories
{
    public class FuncionarioRepository
    {
        //método para exportar os dados de um funcionário
        //para arquivo JSON
        public void Exportar(Funcionario funcionario)
        {
            //serializar os dados do funcionario para JSON
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            using (var streamWriter = new StreamWriter("c:\\temp\\funcionario.json"))
            {
                //gravando o conteudo JSON dentro do arquivo..
                streamWriter.WriteLine(json);
            }
        }

        //método para importar os dados do funcionario de JSON para C#
        public Funcionario Importar()
        {
            //abrindo um arquivo em modo de leitura
            using (var streamReader = new StreamReader("c:\\temp\\funcionario.json"))
            {
                //ler todo o conteudo do arquivo..
                var json = streamReader.ReadToEnd();

                //deserializar o conteudo JSON
                return JsonConvert.DeserializeObject<Funcionario>(json);
            }            
        }
    }
}
