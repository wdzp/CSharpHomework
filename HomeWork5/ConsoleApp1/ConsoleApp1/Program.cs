using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node
    {
        public string num;
        public string name;
        public string people;
        public string money;
    }
    public class OrderService : Node
    {
        List<string> list = new List<string>(1000);
        Node node = new Node();
        public void Add()
        {
            Console.WriteLine("请输入商品编号" + num);
            node.num = Console.ReadLine();
            Console.WriteLine("请输入商品名称" + name);
            node.name = Console.ReadLine();
            Console.WriteLine("请输入您的姓名" + people);
            node.people = Console.ReadLine();
            Console.WriteLine("请输入交易金额" + money);
            node.money = Console.ReadLine();
            list.Add(node.num);
            list.Add(node.name);
            list.Add(node.people);
            list.Add(node.money);
        }
        public void Delete()
        {
            Console.WriteLine("请输入编号进行删除：");
            string choose = Console.ReadLine();
            int i;
            if (list.Contains(choose))
            {
                for (i = 0; i < 1000000; i++)
                {
                    if (list[i] == choose)
                        break;
                }
                list.RemoveAt(i);
                list.RemoveAt(i);
                list.RemoveAt(i);
                list.RemoveAt(i);
            }
            else
            {
                Console.WriteLine("没有该编号！");
            }
        }
        public void Scan()
        {
            Console.WriteLine("请输入姓名进行浏览：");
            string choose = Console.ReadLine();
            int i;
            for (i = 0; i < 1000000; i++)
            {
                if (list[i] == choose)
                    break;
            }
            Console.WriteLine(list[i] + "   " + list[i + 1] + "   " + list[i + 2] + "   " + list[i + 3]);
        }
        bool p = true;
        public void Break()
        {
            p = false;
        }
        public void Linq()
        {
            IEnumerable<string> ie = list.Where((list) => { return list.Length >= 5; });
            foreach (var VARIABLE in ie)
            {
                Console.WriteLine(VARIABLE);
            }
        }
        static void Main(string[] args)
        {
            OrderService or = new OrderService();
            while (or.p)
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
                    case "linq":
                        or.Linq();
                        break;
                }
            }
        }
    }
}

