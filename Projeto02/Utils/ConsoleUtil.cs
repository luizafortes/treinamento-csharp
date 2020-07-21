using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Utils
{
    public class ConsoleUtil
    {
        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int ReadInt(string message)
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine());
        }

        public static decimal ReadDecimal(string message)
        {
            Console.Write(message);
            return decimal.Parse(Console.ReadLine());
        }

        public static DateTime ReadDateTime(string message)
        {
            Console.Write(message);
            return DateTime.Parse(Console.ReadLine());
        }
    }
}
