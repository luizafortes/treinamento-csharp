using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.CrossCutting
{
    public class Criptografia
    {
        //método para receber um valor e retorna-lo criptografado
        public static string MD5Encrypt(string value)
        {
            //criptografando o valor recebido com MD5
            var hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(value));

            //converter o resultado da criptografia para string..
            var result = string.Empty;

            //varrer cada posição do hash
            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> hexadecimal
            }

            return result;
        }
    }
}