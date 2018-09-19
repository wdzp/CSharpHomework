using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            int min = 10000;
            int max = 0;
            int sum = 0;
            double aver = 0;
            Console.WriteLine("请输入数组的长度：");
            int length = Convert.ToInt32(Console.ReadLine());
            a = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("请输入第{0}个数组的值：", i);
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i= 0;i< length;i++)
            {
                if (min > a[i])
                    min = a[i];
            }
            for (int i = 0; i < length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            for (int i = 0; i < length; i++)
            {
                    sum += a[i];
            }
            aver = sum / length;
            Console.WriteLine(min +" "+ max +" "+ sum +" "+ aver);
        }
    }
}
