using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace project1
{
    public class OrderService
    {
        int finalOrder =0;
        public List<Order> orders = new List<Order>();
        public int OrderNu
        {
            get
            {
                return orders.Count()+1;
            }
        }
        public void AddOrder(string orderName,int orderDetailNu)
        {
            Order order = new Order(orderDetailNu, orderName,finalOrder+1);
            try
            {
                Console.WriteLine("创建订单开始" + " " + "名称：" + orderName + " " + "订单号：" +$"{finalOrder+1}");
                for (int i = 0; i < orderDetailNu; i++)
                {
                    Console.WriteLine("输入商品名称");
                    string name = Console.ReadLine();
                    Console.WriteLine("输入商品数量");
                    int nu = int.Parse(Console.ReadLine());
                    Console.WriteLine("输入单价");
                    int price = int.Parse(Console.ReadLine());
                    order.orderDetails[i] = new OrderDetails(name, nu, price);
                }
                orders.Add(order);
                finalOrder += 1;
                Console.WriteLine("创建成功");
            }catch
            {
                Console.WriteLine("数字输入有误");
            }
        }
        public Order InauiryOrder(int OrderID)
        {
            foreach (Order order in orders)
            {
                if (OrderID == order.OrderNu)
                {
                    return order;
                }
            }
            return null;
        }
        public Order InquiryOrder(string orderName)
        {
            foreach (Order order in orders)
            {
                if (orderName == order.Name)
                {
                    return order;
                }
            }

            return null;

        }
        public  List<Order> InquiryByLinq(string orderName)//linq 语句
        {
            var a = from s in orders
                    where s.Name == orderName
                    select s;
            if(a!=null)
            {
                List<Order> b = a.ToList<Order>();
                return b;
            }

            return null;

        }
        public List<Order> InquiryMoneyByLinq(int money)//linq 语句
        {
            var q = from s in orders
                    where (from w in s.orderDetails
                          where w!=null
                          select w.Price).Sum()>=money
                    select s;
            if(q!=null)
            {
                return q.ToList<Order>();
            }

            return null;
        }
        public void ModifyOrder(int orderID)
        {
            OrderDetails orderDetails = null;
            try
            {
                Order order = InauiryOrder(orderID);
                if(order==null)
                {
                    throw new MyException("找不出此条目");
                }
                orders.Remove(order);
                Console.WriteLine("请输入新的名字");
                string orderName = Console.ReadLine();
                Console.WriteLine("输入要修改的条目名称");
                string detailName = Console.ReadLine();
                for(int i =0;i<order.OrderNu;i++)
                {
                    if(detailName==order.orderDetails[i].Name)
                    {
                        orderDetails = order.orderDetails[i];
                    }
                }
                Console.WriteLine("输入要改的数量");
                try
                {
                    orderDetails.Nu = int.Parse(Console.ReadLine());
                }catch(MyException e)
                {
                    throw new MyException("输入数字有误", e);
                }
                Console.WriteLine("修改成功");
            }catch(MyException e)
            {
                if(e.InnerException!=null)
                {

                    Console.WriteLine("内部原有  " + e.Message);
                }
                Console.WriteLine(e.Message );
            }
            
        }
        public void DeleteOrder(int orderID)
        {
            try
            {
                Order order = InauiryOrder(orderID);
                if(order==null)
                {
                    throw new MyException("找不出此条目");
                }
                orders.Remove(InauiryOrder(orderID));
                Console.WriteLine("删除成功");
            }catch(MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool Export(string fileName)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                xmlSer.Serialize(fs, orders);
                fs.Close();
                return true;
            }catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
            
        }
        public bool Import(string fileName)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
                FileStream fs = new FileStream(fileName, FileMode.Open);
                var orders = xmlSer.Deserialize(fs) as List<Order>;
                foreach (Order order in orders)
                {
                    this.orders.Add(order);
                }
                fs.Close();
                return true;
            }catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }
    }
    class MyException : ApplicationException
    {
        public MyException(string message):base(message)
        {

        }
        public MyException(string message,Exception inner):base(message,inner)
        {

        }
    }
}
