using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductManager productManager = new ProductManager(new InMemoryDal());
        private void button1_Click(object sender, EventArgs e)
        {
            Product product1 = new Product();
            product1.ProductId = Int32.Parse(textBox1.Text);
            product1.CategoryId = Int32.Parse(textBox2.Text);
            product1.ProductName = textBox3.Text;
            product1.UnitPrice = short.Parse(textBox4.Text);
            product1.UnitsInStock = (short)Convert.ToDecimal(textBox5.Text);
            productManager.Add(product1);

            dataGridView1.DataSource = productManager.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
