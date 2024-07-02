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
    public partial class Incert_T : Form
    {
        public Incert_T()
        {
            InitializeComponent();
        }
        Magazin magazin = new Magazin();

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into tovar(nazvanie,stoimost,kolichestvo,postavshik)" +
            " values ('" + textBox1.Text + "','" + textBox2.Text + "','"+ textBox3.Text + "','" + comboBox1.SelectedValue + "')";

            int con = magazin.Connection();
            if (con == 1)
            {
                int result = magazin.Query_IUD(query);
                if (result != -1)
                {
                    MessageBox.Show("Данные успешно добавлены");

                    DataTable tab = new DataTable();
                    tab = magazin.Select_Query("select nazvanie, stoimost from tovar");
                    dataGridView1.DataSource = tab;
                    dataGridView1.Visible = true;
                }
                else
                    MessageBox.Show("Ошибка при добавлении данных");
            }
            else
                MessageBox.Show("Ошибка при соиденениее с БД");
        }

        private void Incert_T_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "magazinDataSet.postavshik". При необходимости она может быть перемещена или удалена.
            this.postavshikTableAdapter.Fill(this.magazinDataSet.postavshik);
            int k = magazin.Connection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tovar tovar = new Tovar();
            tovar.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
