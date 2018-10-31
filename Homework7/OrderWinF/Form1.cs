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
    public partial class Form1 : Form
    {
        public OrderService service;
        public Form1()
        {
            
            OrderService service = new OrderService();
            this.service = service;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = service.orders.ToArray();
            if (dataGridView1.CurrentCell != null)
            {
                dataGridView2.DataSource = dataGridView2.DataSource = service.orders[
                    dataGridView1.CurrentCell.RowIndex
                    ].orderDetails;
            }



            dataGridView1.CurrentCellChanged += dataGrid1_CurrentCellChanged;

        }
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            if (dataGridView1.CurrentCell != null)
            {
                dataGridView2.DataSource = dataGridView2.DataSource = service.orders[
                    dataGridView1.CurrentCell.RowIndex
                    ].orderDetails;
            }
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.service = this.service;
            form2.ShowDialog();

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = service.orders.ToArray();
            if (dataGridView1.CurrentCell != null)
            {
                dataGridView2.DataSource = service.orders[
                    dataGridView1.CurrentCell.RowIndex
                    ].orderDetails;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void deleteByName_Click(object sender, EventArgs e)
        {
            try
            {
                List<Order> list = service.InquiryByLinq(textBox1.Text);
                foreach (Order order in list)
                {
                    service.DeleteOrder(order.OrderNu);
                }
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = service.orders.ToArray();
                if (dataGridView1.CurrentCell != null)
                {
                    dataGridView2.DataSource = service.orders[
                        dataGridView1.CurrentCell.RowIndex
                        ].orderDetails;
                }
            }
            catch
            {

            }
        }

        private void deleteById_Click(object sender, EventArgs e)
        {
            try
            {
                service.DeleteOrder(int.Parse(textBox2.Text));
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = service.orders.ToArray();
                if (dataGridView1.CurrentCell != null)
                {
                    dataGridView2.DataSource = service.orders[
                        dataGridView1.CurrentCell.RowIndex
                        ].orderDetails;
                }
            }
            catch
            {

            }
        }
        private void InquiryByName_Click(object sender, EventArgs e)
        {
            try
            {
                Order[] orders= service.InquiryByLinq(textBox3.Text).ToArray();
                dataGridView1.DataSource = orders;
                if (dataGridView1.CurrentCell != null)
                {
                    dataGridView2.DataSource = service.orders[
                        dataGridView1.CurrentCell.RowIndex
                        ].orderDetails;
                }
            }catch
            {

            }
        }

        private void InquiryById_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = service.InauiryOrder(int.Parse(textBox4.Text));
                Order[] orders = new Order[] { order };
                dataGridView1.DataSource = orders;
                if (dataGridView1.CurrentCell != null)
                {
                    dataGridView2.DataSource = service.orders[
                        dataGridView1.CurrentCell.RowIndex
                        ].orderDetails;
                }
            }catch
            {

            }
        }
    }
}
