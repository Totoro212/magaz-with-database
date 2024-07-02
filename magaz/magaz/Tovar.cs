using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magaz
{
    public partial class Tovar : Form
    {
        public Tovar()
        {
            InitializeComponent();
        }
        Magazin magazin=new Magazin();
        private void button1_Click(object sender, EventArgs e)
        {
            //Magazin ob = new Magazin();
            int k= magazin.Connection();
            if (k == 1)
            {
                string zapros = "select t.nazvanie, t.stoimost, kolichestvo, p.nazvaniye from tovar t, postavshik p where t.postavshik = p.id_postavshik ";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(zapros);
                dataGridView1.Refresh();
                dataGridView1.DataSource = tab;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Incert_T inst = new Incert_T();
            inst.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string que = "select t.nazvanie, t.stoimost" +
                " from tovar t where t.nazvanie='" + textBox1.Text + "'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(que);
            dataGridView1.DataSource = tab;
        }

        private void Tovar_Load(object sender, EventArgs e)
        {
            int con = magazin.Connection();
        }

        static int row;
        private void button3_Click(object sender, EventArgs e)
        {
            row = dataGridView1.CurrentRow.Index;
            textBox2.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            label2.Visible = true;
            label3.Visible = true;
            label7.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox5.Visible = true;
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string que = "update tovar set nazvanie='" + textBox2.Text + "',stoimost='" + textBox3.Text + "', kolichestvo='"+ textBox5.Text+"'"
                        + " where nazvanie='" + dataGridView1.Rows[row].Cells[0].Value + "'";
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

        private void button7_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*string deleteQuery = "delete from tovar where id_tovar='" + dataGridView1.Rows[row].Cells[0].Value + "'";*/
            string deleteQuery = "delete from tovar where id_tovar=" + dataGridView1.Rows[row].Cells[0].Value;

            int rowsAffected = magazin.Query_IUD(deleteQuery);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Удаление успешно выполнено");
            }
            else
            {
                MessageBox.Show("Удаление не выполнено. Запись не найдена.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string que = "select nazvanie, stoimost " +
                    "from tovar where stoimost>'" + textBox4.Text + "'";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(que);
                dataGridView1.DataSource = tab;
            }
            else if (radioButton2.Checked)
            {
                string que = "select nazvanie, stoimost " +
                    "from tovar where stoimost<'" + textBox4.Text + "'";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(que);
                dataGridView1.DataSource = tab;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string que = "select distinct p.nazvaniye" +
                " from tovar t, postavshik p where t.postavshik=p.id_postavshik";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(que);
            dataGridView1.DataSource = tab;
        }
    }
}
