using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataTDD.Lib.Diamonds;

namespace DiamonConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string diamond = Diamond.Create(args[0][0]);
            Console.WriteLine(diamond);
            Console.ReadLine();
        }
    }
}
