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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace magaz
{
    public partial class Pokupatel : Form
    {
        public Pokupatel()
        {
            InitializeComponent();
        }
        Magazin magazin = new Magazin();
        private void button1_Click(object sender, EventArgs e)
        {
            int k = magazin.Connection();
            if (k == 1)
            {

                string zapros = "select nazvanie, stoimost,id_tovar, kolichestvo from tovar";
                DataTable tab = new DataTable();
                tab = magazin.Select_Query(zapros);
                dataGridView1.DataSource = tab;
                dataGridView1.Columns[2].Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string que = "select t.nazvanie, t.stoimost, t.kolichestvo " +
                "from tovar t " +
                "where t.nazvanie='" + textBox1.Text + "'";
            DataTable tab = new DataTable();
            tab = magazin.Select_Query(que);
            dataGridView1.DataSource = tab;
        }

        private void Pokupatel_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "magazinDataSet.client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.magazinDataSet.client);
            int k = magazin.Connection();
        }
        static int row;

        private void button2_Click(object sender, EventArgs e)
        {
            row = dataGridView1.CurrentRow.Index;
            
            int stoimost = Convert.ToInt32(dataGridView1.Rows[row].Cells[1].Value);

            


            DataTable zabrat = new DataTable();
            zabrat = magazin.Select_Query("select kolichestvo from tovar");
            dataGridView2.DataSource = zabrat;
            int skolko_est = Convert.ToInt32(dataGridView2.Rows[row].Cells[0].Value.ToString());
            string textBoxValue = textBox3.Text;

            if (string.IsNullOrEmpty(textBoxValue))
            {
                MessageBox.Show("Введите количество");
            }
            else if (skolko_est >= Convert.ToInt32(textBox3.Text))
            {
                string query = "insert into prodaji(client,tovar,kolichestvo,stoimost)" +
                " values ('" + comboBox1.SelectedValue + "','" +
                Convert.ToInt32(dataGridView1.Rows[row].Cells[2].Value) + "','" +
                Convert.ToInt32(textBox3.Text) + "','" +
                stoimost * Convert.ToInt32(textBox3.Text) + "')";
                int skolko_ostalos = skolko_est - Convert.ToInt32(textBox3.Text);
                string que = "update tovar set kolichestvo='" + skolko_ostalos + "' where nazvanie = '"+dataGridView1.Rows[row].Cells[0].Value+"'";
                magazin.Query_IUD(que);
                int con = magazin.Connection();
                if (con == 1)
                {
                    int result = magazin.Query_IUD(query);
                    if (result != -1)
                    {
                        MessageBox.Show("Данные успешно добавлены");
                        DataTable tab = new DataTable();
                        tab = magazin.Select_Query("select nazvanie, stoimost, kolichestvo from tovar");
                        dataGridView1.DataSource = tab;
                        dataGridView1.Visible = true;
                    }
                    else
                        MessageBox.Show("Ошибка при добавлении данных");
                }
                else
                    MessageBox.Show("Ошибка при соиденениее с БД");
            }
            else
            {
                MessageBox.Show("Такого количества нету");
            }
        }
    }
}
