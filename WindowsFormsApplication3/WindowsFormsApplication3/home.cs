using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form d = new Doctors();
            d.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form d = new Doctors();
            d.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form p = new Form2();
            p.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form p = new Form2();
            p.Show();
            this.Hide();
        }
    }
}
