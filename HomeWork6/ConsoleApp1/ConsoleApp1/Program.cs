using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
namespace TestSerialize
{
    public class Order
    {
        public string num{ get; set; }
        public string name{ get; set; }
        public string people{ get; set; }
    }
    public class OrderService
    {
        public void Export()
        {
            Order order = new Order();
            order.num = Console.ReadLine();
            order.name = Console.ReadLine();
            order.people = Console.ReadLine();
            var xDoc = new XDocument(new XElement("root",
                new XElement("编号",
                new XText(order.num),
                new XAttribute("名称", order.name)),
                new XAttribute("姓名", order.people)));
            StreamWriter sw = new StreamWriter(new FileStream(@"d:\t.xml", FileMode.Create),
                Encoding.UTF8);
            xDoc.Save(sw);
            xDoc.Save(Console.Out);
        }
        public void Import()
        {
            var xDoc = new XDocument(new XElement("root",
                new XElement("dog",
                new XText("小狗"),
                new XAttribute("color", "black")),
            new XElement("cat"),
            new XElement("pig", "小猪")));
            StreamWriter sw = new StreamWriter(new FileStream(@"d:\t.xml", FileMode.Create),
                Encoding.UTF8);
            xDoc.Save(sw);
            var query = from item in xDoc.Element("root").Elements()
                select new
                {
                    TypeName = item.Name,
                    Saying = item.Value,
                    Color = item.Attribute("color") == null
                    ? null : item.Attribute("color").Value
                };
            foreach(var item in query)
            {
                Console.WriteLine("{0}'s color is {1},{0} said {2}",
                    item.TypeName,
                    item.Color??"Unkown",
                    item.Saying??"nothing");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService order = new OrderService();
            var a = Console.ReadLine();
            switch(a)
            {
                case "export":
                    order.Export();
                    break;
                case "import":
                    order.Import();
                    break;
            }
        }
    }
}