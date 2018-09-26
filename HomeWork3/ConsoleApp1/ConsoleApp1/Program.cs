using System;

namespace ConsoleApp1

{

    class Program

    {
        static void Main(string[] args)

        {

            Gra go = new Gra();

            string h = Console.ReadLine();

            go = OperationFactory.createOperate(h);

            string lz = Console.ReadLine();

            go.L = Convert.ToDouble(lz);

            string wd= Console.ReadLine();

            go.W = Convert.ToDouble(wd);

            double result = go.GetResult();

            Console.WriteLine("结果是：" + result);

        }
        public class Gra  

        {

            private double l = 0;

            private double w = 0;

            public double L

            {

                get { return l; }

                set { l = value; }

            }

            public double W

            {

                get { return w; }

                set { w = value; }

            }

            public virtual double GetResult()

            {

                double result = L * W;

                return result;

            }

        }

        class Tri : Gra   //三角

        {

            public override double GetResult()  

            {

 

                double result = 0;

                result = L * W /2;

                return result;

            }

        }

        class Rec : Gra    //矩形

        {

            public override double GetResult()

            {

                double result = 0;

                result = L * W;

                return result;

            }

        }

        class Squ : Gra   //正方形  

        {

            public override double GetResult()

            {

                double result = 0;

                result = L * W;

                return result;

            }

        }

        class Cir : Gra    //圆形

        {

            public override double GetResult()

            {

                double result = 0;

                result = Math.PI*L*L;

                return result;

            }

        }
        public class OperationFactory

        {

            public static Gra createOperate(string Gra)

            {

                Gra oper = new Gra();

                 switch (Gra)

                {

                     case "Tri":

                         oper = new Tri();

                         break;

                     case "Rec":
                    
                         oper = new Rec();

                         break;

                     case "Squ":

                          oper = new Squ();

                          break;

                     case "Cir":

                          oper = new Cir();

                          break;

                 }

                return oper;

            }

        }

    }

}
