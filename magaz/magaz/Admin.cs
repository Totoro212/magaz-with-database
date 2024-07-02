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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        Magazin mag = new Magazin();
        private void button1_Click(object sender, EventArgs e)
        {
            if (mag.Connection() == 1)
            {
                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tovar tovar = new Tovar();
            tovar.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prodaji prodaji = new Prodaji();
            prodaji.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Hide();
        }
    }
}
