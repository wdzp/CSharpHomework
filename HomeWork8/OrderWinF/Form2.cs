using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project1;

namespace OrderWinF
{
    
    public partial class Form2 : Form
    {
        int count=0;
        public OrderService service;
        public Form2()
        {
            
            InitializeComponent();
          


        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Random co = new Random();
            int i = co.Next(1,999);
            string number = DateTime.Now.ToString("yyMMdd") + i.ToString();
            this.Text = "订单号为"+ number;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void creat_b_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order( textBox1.Text, service.OrderNu, textBox3.Text);
                service.orders.Add(order);
                creat_b.Enabled = false;
                if(textBox3.Text.Length!=11)
                {
                    this.Text = "号码不合法";
                }
                else
                {
                    button2.Enabled = true;
                }
                textBox1.Enabled = false;
                textBox3.Enabled = false;
            }
            catch
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            creat_b.Enabled = false;
            textBox3.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void detailNu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
