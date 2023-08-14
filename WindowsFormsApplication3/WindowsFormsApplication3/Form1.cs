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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("admin@1234") && comboBox1.Text.Equals("Administrator"))
            {
                Form f2 = new home();
                f2.Show();
                this.Hide();
            }
            else if (textBox2.Text.Equals("truntrun@123") && comboBox1.Text.Equals("Other")) {
                Form f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else if (comboBox1.Text.Equals("") && textBox2.Text.Equals("")) {
                MessageBox.Show("Enter all details");
            }
            else
            {
                MessageBox.Show("Incorrect Password Or Username");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
