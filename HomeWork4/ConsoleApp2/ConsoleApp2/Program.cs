using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class OrderService
    {
        public class Order : OrderService
        {
            public string num;
            public string name;
            public string people;
            public class OrderDetails : Order
            {
                List<string> list1 = new List<string>(1000000);
                List<string> list2 = new List<string>(1000000);
                List<string> list3 = new List<string>(1000000);
                public void Add()
                {
                    Console.WriteLine("请输入商品编号" + num);
                    num = Console.ReadLine();
                    Console.WriteLine("请输入商品名称" + name);
                    name = Console.ReadLine();
                    Console.WriteLine("请输入您的姓名" + people);
                    people = Console.ReadLine();
                    list1.Add(num);
                    list2.Add(name);
                    list3.Add(people);
                }
                public void Delete()
                {
                    Console.WriteLine("请输入姓名进行删除：");
                    string choose = Console.ReadLine();
                    int i ;
                    if(list3.Contains(choose))
                    {
                        for (i = 0; i < 1000000; i++)
                        {
                            if (list3[i] == choose)
                                break;
                        }
                        list1.RemoveAt(i);
                        list2.RemoveAt(i);
                        list3.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("没有该姓名！");
                    }
                }
                public void Scan()
                {
                    Console.WriteLine("请输入姓名进行浏览：");
                    string choose = Console.ReadLine();
                    int i;
                    for (i = 0; i < 1000000; i++)
                    {
                        if (list3[i] == choose)
                            break;
                    }
                    Console.WriteLine(list1[i] + "   " + list2[i] + "   " + list3[i]);
                }
                bool p = true;
                public void Break()
                {
                    p = false;
                }
                static void Main(string[] args)
                {
                    OrderDetails or = new OrderDetails();
                    while(or.p)
                    {
                        Console.WriteLine("请输入要进行的操作：");
                        string action = Console.ReadLine();
                        switch (action)
                        {
                            case "add":
                                or.Add();
                                break;
                            case "delete":
                                or.Delete();
                                break;
                            case "scan":
                                or.Scan();
                                break;
                            case "break":
                                or.Break();
                                break;
                        }
                    }
                }
            }
        }
    }
}
