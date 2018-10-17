using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree1(10, 200, 310, 100, -Math.PI / 2);
        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        void drawCayleyTree1(int n, double x0, double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine1(x0, y0, x1, y1);
            drawCayleyTree1(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree1(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawCayleyTree2(int n, double x0,double y0,double x2,double y2, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x3 = x2 + leng * Math.Cos(th);
            double y3 = y2 + leng * Math.Sin(th);
            drawLine1(x0, y0, x1, y1);
            drawLine1(x2, y2, x3, y3);
            drawCayleyTree2(n - 1, x1, y1, x3, y3, per1 * leng, th + th1);
            drawCayleyTree2(n - 1, x1, y1, x3, y3, per2 * leng, th - th2);
        }
        void drawLine1(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        void drawLine2(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree2(10, 200, 310, 400, 310, 100, -Math.PI / 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree3(10, 200, 310, 100, -Math.PI / 2);
            void drawCayleyTree3(int n, double x0, double y0, double leng, double th)
            {
                double an1 = Convert.ToDouble(textBox1.Text);
                double an2 = Convert.ToDouble(textBox2.Text);
                double t1 = an1 * Math.PI / 180;
                double t2 = an2 * Math.PI / 180;
                double k = Convert.ToDouble(this.textBox3.Text);
                if (n == 0) return;
                double x1 = x0 + k * leng * Math.Cos(th);
                double y1 = y0 + k * leng * Math.Sin(th);
                drawLine2(x0, y0, x1, y1);
                drawCayleyTree3(n - 1, x1, y1, per1 * leng, th + t1);
                drawCayleyTree3(n - 1, x1, y1, per2 * leng, th - t2);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
