using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string main = "пирамида";
             
            string d = main.Substring(6, 1); 
            string a = main.Substring(7, 1); 
            string i = main.Substring(1, 1); 
            string m = main.Substring(4, 1); 
            
            string dima = d + i + m + a;

            string ir = main.Substring(1, 1); 
            string ra = main.Substring(2, 2); 
            string ida = main.Substring(5, 3); 

            string iraida = ir + ra + ida;

            Console.WriteLine($"Исходное слово: " + main);
            Console.WriteLine("Полученное имя 'дима': " + dima);
            Console.WriteLine("Полученное имя 'ираида': " + iraida);
        }
    }
}
