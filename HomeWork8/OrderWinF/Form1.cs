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
        string tH(DataTable datatable)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in datatable.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in datatable.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in datatable.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            return Htmltext;

        }
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
            }
            dataGridView1.CurrentCellChanged += dataGrid1_CurrentCellChanged;

        }
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
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
            dataGridView1.DataSource = service.orders.ToArray();
            if (dataGridView1.CurrentCell != null)
            {
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
                dataGridView1.DataSource = service.orders.ToArray();
                if (dataGridView1.CurrentCell != null)
                {
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
                dataGridView1.DataSource = service.orders.ToArray();
                if (dataGridView1.CurrentCell != null)
                {
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
                }
            }catch
            {

            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string a = Convert.ToString(181115001);
            dt.Columns.Add("订单号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("商品名称", typeof(string));
            dt.Columns.Add("价格", typeof(int));
            dt.Rows.Add(181115001, 1, 1, 1);
            dt.Rows.Add(181115002, 2, 2, 2);
            dt.Rows.Add(181115003, 3, 3, 3);
            dt.Rows.Add(181115004, 4, 4, 4);
            tH(dt);
            dataGridView2.DataSource = dt;
            button3.Text= tH(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
