using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace magaz
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        Magazin magazin = new Magazin();
        private void button1_Click(object sender, EventArgs e)
        {
            int k = magazin.Connection();
            if (k == 1)
            {
                string zapros = "select * from client";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(zapros);
                dataGridView1.DataSource = tab;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            int k = magazin.Connection();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string zapros = "select * from client c where c.imya like '" + textBox1.Text + "%'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(zapros);
            dataGridView1.DataSource = tab;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string zapros = "select * from client where familiya like '" + textBox2.Text + "%'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(zapros);
            dataGridView1.DataSource = tab;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string zapros = "select * from client where telefon like '" + textBox3.Text + "%'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(zapros);
            dataGridView1.DataSource = tab;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string zapros = "select * from client where el_pochta like '" + textBox4.Text + "%'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(zapros);
            dataGridView1.DataSource = tab;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) ||  string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                // Текстовое поле пусто
                MessageBox.Show("есть не введеное поле");
            }
            else
            {
                string query = "insert into client(imya,familiya,telefon,el_pochta)" +
            " values ('" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                int result = magazin.Query_IUD(query);
                if (result != -1)
                {
                    MessageBox.Show("Данные успешно добавлены");
                    /*
                                    DataTable tab = new DataTable();
                                    tab = magazin.Select_Query("select nazvanie, stoimost from tovar");
                                    dataGridView1.DataSource = tab;
                                    dataGridView1.Visible = true;*/
                }
                else
                    MessageBox.Show("Ошибка при добавлении данных");
            }
        }
        static int row;
        private void button8_Click(object sender, EventArgs e)
        {
            row = dataGridView1.CurrentRow.Index;

            string que = "update client set " +
                "imya='" + textBox5.Text + "',familiya='" + textBox6.Text + "',telefon='" + textBox7.Text + "',el_pochta='" + textBox8.Text + "'"
                        + " where imya='" + dataGridView1.Rows[row].Cells[1].Value + "'";
            int result = magazin.Query_IUD(que);
            if (result != -1)
            {
                MessageBox.Show("Данные успешно изменены");

            }
            else
            {
                MessageBox.Show("Ошибка при изменении данных");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                // Текстовое поле пусто
                MessageBox.Show("есть не введеное поле");
            }
            else
            {
                string que = "DELETE FROM client WHERE id_client = " + dataGridView1.Rows[row].Cells[0].Value;
                int result = magazin.Query_IUD(que);
                if (result != -1)
                {
                    MessageBox.Show("Данные успешно изменены");

                }
                else
                {
                    MessageBox.Show("Ошибка при изменении данных");
                }
            }
        }
    }
}
