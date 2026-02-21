using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Logger
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} > " + message);
        }
    }
}
