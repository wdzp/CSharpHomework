using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    [Serializable]
    public class Order
    {
        public Order()
        {

        }
        public Order(string name,int orderNu,string tel)
        {
            this.Name = name;
            this.OrderNu = orderNu;
            this.Tel = tel;
        }
        public string Name { get; set; }
        public int OrderNu { get;set ;}
        public string Tel { get; set; }

        public OrderDetails[] orderDetails;

    }
}
