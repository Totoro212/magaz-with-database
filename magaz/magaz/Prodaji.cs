using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magaz
{
    public partial class Prodaji : Form
    {
        public Prodaji()
        {
            InitializeComponent();
        }
        Magazin magazin = new Magazin();
        private void button1_Click(object sender, EventArgs e)
        {
            int k = magazin.Connection();
            if (k == 1)
            { 
                string zapros = "select c.imya, t.nazvanie, p.kolichestvo, p.stoimost, p.data_prodaji, p.data_dostavki from prodaji p, client c, tovar t where p.client = c.id_client and p.tovar = t.id_tovar";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(zapros);
                dataGridView1.DataSource = tab;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                string que = "select c.imya, t.nazvanie, p.kolichestvo, p.stoimost, p.data_prodaji, p.data_dostavki " +
                    "from prodaji p, client c, tovar t where p.client = c.id_client and p.tovar = t.id_tovar and p.stoimost>'" + textBox1.Text + "'";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(que);
                dataGridView1.DataSource = tab;
            }
            else if (radioButton2.Checked)
            {
                string que = "select c.imya, t.nazvanie, p.kolichestvo, p.stoimost, p.data_prodaji, p.data_dostavki " +
                    "from prodaji p, client c, tovar t where p.client = c.id_client and p.tovar = t.id_tovar and p.stoimost<'" + textBox1.Text + "'";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(que);
                dataGridView1.DataSource = tab;
            }

        }

        private void Prodaji_Load(object sender, EventArgs e)
        {
            int k=magazin.Connection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string que = "select t.nazvanie, c.familiya,p.kolichestvo, p.data_prodaji " +
                "from client c, prodaji p, tovar t " +
                "where p.client = c.id_client and p.tovar = t.id_tovar and t.nazvanie='" + textBox2.Text + "'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(que);
            dataGridView1.DataSource = tab;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int ob_summa = 0;

            string que = "select sum(stoimost) from prodaji";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(que);
            dataGridView2.DataSource = tab;

           label5.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string que = "select t.nazvanie, c.familiya,p.kolichestvo, p.data_prodaji " +
                "from client c, prodaji p, tovar t " +
                "where p.client = c.id_client and p.tovar = t.id_tovar and t.nazvanie='" + textBox3.Text + "'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(que);
            dataGridView1.DataSource = tab;
        }
    }
}
