using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIWinForm
{
    public partial class Form1 : Form
    {
        CN_Customer cn_Customer = new CN_Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = cn_Customer.SelectCustomer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Customer customer = new Customer();
            customer.IdCustomer = string.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text);
            customer.Names = textBox2.Text;
            customer.LastName = textBox3.Text;
            customer.DNI = textBox4.Text;
            customer.Email = textBox5.Text;

            if (customer.IdCustomer > 0)
                //Actualizar
                cn_Customer.UpdateCustomer(customer, out mensaje);
            else
                //Agregar
                cn_Customer.InsertCustomer(customer, out mensaje);

            if (!string.IsNullOrEmpty(mensaje))
                MessageBox.Show(mensaje);
            else
            {
                Limpiar();
                CargarDatos();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (MessageBox.Show("Seguro de eliminar el cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn_Customer.DeleteCustomer(Convert.ToInt32(textBox1.Text));
                    Limpiar();
                    CargarDatos();
                }
                    
            }
            else
                MessageBox.Show("Selecione un cliente para eliminar");
        }
    }
}
