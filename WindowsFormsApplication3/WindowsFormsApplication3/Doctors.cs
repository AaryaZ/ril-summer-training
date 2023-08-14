using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{
    public partial class Doctors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=10.3.71.132;Initial Catalog=HMS;User ID=Aarya;Password=Hospital@01");
        string type = ""; 
       
        SqlCommand cmd;
        public Doctors()
        {
            InitializeComponent();
        }

        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.Doctorview", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals("Regular")){
                type = "regular";
            }
            else if (comboBox1.Text.Equals("Visiting"))
            {
                type = "visiting";
            }
            else {
                MessageBox.Show("Empty Field");
            }

            cmd = new SqlCommand("INSERT INTO Doctors(D_ID,DName,Speciality,DType,Salary,Mobile_No) VALUES(@id,@name,@sp,@type,@salary,@mobile)", con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@id", numericdid.Value);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@sp", textBox2.Text);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@salary",int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@mobile", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                LoadAllRecords();
            }
            catch (Exception cat)
            {
                MessageBox.Show("Record not inserted");
                MessageBox.Show(cat.ToString());
            }


        }



        private void button3_Click(object sender, EventArgs e)
        {
            
            cmd = new SqlCommand("DELETE FROM Doctors WHERE D_ID=@did", con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@did", numericdid.Value);
                
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully");
                LoadAllRecords();
            }
            catch (Exception cat)
            {
                MessageBox.Show("Record not deleted");
                MessageBox.Show(cat.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Regular"))
            {
                type = "regular";
            }
            else if (comboBox1.Text.Equals("Visiting"))
            {
                type = "visiting";
            }
            else
            {
                MessageBox.Show("Empty Field");
            }

            cmd = new SqlCommand("UPDATE Doctors SET DName=@name,Speciality=@sp,DType=@type,Salary=@salary,Mobile_No=@mobile WHERE D_ID=@did", con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@did", numericdid.Value);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@sp", textBox2.Text);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@salary", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@mobile", long.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully");
                LoadAllRecords();
            }
            catch (Exception cat)
            {
                MessageBox.Show("Record not updated");
                MessageBox.Show(cat.ToString());
            }
        }
    }
}
