using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ServiceApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Mike = new User("Mike");

            Thread.Sleep(5000);
            WebService.Login(Mike);
            Thread.Sleep(2000);

        }
    }
}
