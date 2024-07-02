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
    public partial class Admin_enter : Form
    {
        public Admin_enter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1" && textBox2.Text == "1")
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверно");
            }
        }
    }
}
