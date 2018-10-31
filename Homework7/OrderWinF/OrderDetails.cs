using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class OrderDetails
    {
        public OrderDetails()
        {

        }
        public OrderDetails(string name,int nu,int price)
        {
            this.name = name;
            this.Nu = nu;
            this.eachPrice = price;
        }
        public string name;
        public string Name
        {
            get
            {
               return name;
            }
        }
        public int Nu { get; set; }
        public int eachPrice;
        public int EachPrice
        {
            get
            {
                return eachPrice;
            }
        }
        public int Price
        {
            get
            {
                return EachPrice * Nu;
            }
        }

    }
}
