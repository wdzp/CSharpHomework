using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            bool b = true;

            foreach (int c in Enumerable.Range(2, a - 2))

            {

                if (a % c == 0)

                {

                    b = true;

                    break;

                }

                else b = false;

            }

            if (b)
            {

                int y = 2; string s = " 合数:";

                foreach (int c in Enumerable.Range(2, a - 2))

                    if (a % c == 0)

                        while (y <= a / c)

                            if ((int)Math.Pow(c, y++) == a)

                            {

                                s += string.Join("*", Enumerable.Repeat(c, --y));

                                b = false;

                                break;

                            }

                Console.WriteLine(b ? "非质数、合数" : a + s);

            }


        }
    }
}
