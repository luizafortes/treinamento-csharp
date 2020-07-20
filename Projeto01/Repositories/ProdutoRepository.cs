using Projeto01.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//localização da classe no projeto
namespace Projeto01.Repositories
{
    //declaração da classe
    public class ProdutoRepository
    {
        //método para exportar os dados do produto para aqrquivo TXT
        public void GravarArquivo(Produto produto)
        {
            var path = "c:\\temp\\";

            //criando a pasta
            CriarDiretorio(path);

            //criando/abrindo um arquivo em modo de escrita (StreamWriter)
            //realizando a abertura do arquivo de modo a fecha-lo ao final do uso
            using (var streamWriter = new StreamWriter(path + "produtos.txt", true))
            {
                //gravar os dados do produto no arquivo..
                streamWriter.WriteLine("Codigo......: " + produto.Codigo);
                streamWriter.WriteLine("Nome........: " + produto.Nome);
                streamWriter.WriteLine("Preço.......: " + produto.Preco);
                streamWriter.WriteLine("Quantidade..: " + produto.Quantidade);
                streamWriter.WriteLine("---");

            }
        }

        //método para criar uma pasta utilizada para gravação do arquivo
        private void CriarDiretorio(string path)
        {
            //verificar se o diretorio não existe..
            if (!Directory.Exists(path))
            {
                //criar o diretorio
                Directory.CreateDirectory(path);
            }
        }
    }    
}
