using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Time : EventArgs
    {
        public int h;
        public int m;
        public int s;
    }
    public delegate void TimeNow(object sender, Time e);
    public class Ti
    {
        public void DoSet()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            bool q = true;
            while (q)
            {
                Time args = new Time();
                args.h = DateTime.Now.Hour;
                args.m = DateTime.Now.Minute;
                args.s = DateTime.Now.Second;
                if (args.h == a & args.m == b&args.s==c)
                    q = false;
            }
        }
    }
    public class TimeSet
    {
        static void Main()
        {
            Ti ti = new Ti();
            ti.DoSet();
        }
    }
}
