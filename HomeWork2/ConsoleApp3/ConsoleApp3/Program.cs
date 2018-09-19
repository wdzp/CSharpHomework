using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            for (i = 2; i < 100; i++)
            {
                for (j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                        break;
                }
                if (j > i / 2)
                    Console.WriteLine("质数: " + i);
            }
        }
    }
}
