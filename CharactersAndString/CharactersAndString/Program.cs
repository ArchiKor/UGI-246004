using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersAndString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = 'z';

            letter = (char)0x42F;

            Console.WriteLine(letter);
            Console.WriteLine(char.ToLower(letter));
        }
    }
}
