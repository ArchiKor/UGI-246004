using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)

        {
            var rstr = Console.ReadLine();
            var flag = false;
            for (var charIndex = 0; charIndex < rstr.Length; charIndex++)
            {
                if (flag || rstr[charIndex] != '\\')
                    Console.Write(rstr[charIndex]);
                flag = rstr[charIndex] == '\\';
            }
        }
    }
}
