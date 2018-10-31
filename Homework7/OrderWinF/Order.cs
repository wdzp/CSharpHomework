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
        public Order(int orderDetailNu,string name,int orderNu)
        {
            orderDetails = new OrderDetails[orderDetailNu];
            this.Name = name;
            this.OrderNu = orderNu;
        }
        public string Name { get; set; }
        public int OrderNu { get;set ;}

        public OrderDetails[] orderDetails;

    }
}
