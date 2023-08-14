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
    public partial class Form2 : Form
    {
     
        SqlConnection con = new SqlConnection("Data Source=10.3.71.132;Initial Catalog=HMS;User ID=Aarya;Password=Hospital@01");
        /* SqlConnection con = new SqlConnection("Data Source=10.3.71.132;Initial Catalog=HMS;Persist Security Info=True;User ID=Aarya;Password=Hospital@01");*/
       
       
        string gender = "";
        string Dept = "";
        SqlCommand cmd;
       



        public Form2()
        {
            InitializeComponent();
        }
        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.Patientsview", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {   /*Department IPD OPD*/
            if(radioButton1.Checked==true){
                Dept="I";
               /* Form f3 = new Form3();*/
            }
            else if(radioButton2.Checked==true){
                Dept="O";
              /*  Form f3 = new Form4(); */
            }
            else{
            MessageBox.Show("Select Department");
            }

            /*Gender*/
             if(radioButton3.Checked==true){
                gender="M";
            }
            else if(radioButton4.Checked==true){
                gender="F";
            }
            else{
            MessageBox.Show("Select Gender");
            }


            cmd = new SqlCommand("INSERT INTO Patients(PName,Age,Phone,Doctor_ID,Department,Case_ID,gender) VALUES(@name,@age,@phone,@did,@Dept,@cid,@gender)", con);
            try
            {
                try
                {
                    con.Open();
                }
                finally
                {
                    cmd.Parameters.AddWithValue("@name", textBoxname.Text);
                    cmd.Parameters.AddWithValue("@age", numericage.Value);
                    cmd.Parameters.AddWithValue("@phone", long.Parse(textBoxphone.Text));
                    cmd.Parameters.AddWithValue("@did", numericdid.Value);
                    cmd.Parameters.AddWithValue("@Dept", Dept);
                    cmd.Parameters.AddWithValue("@cid", numericUpDown3.Value);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully");
                    LoadAllRecords();
                }
            }
            catch (Exception cat) {
                MessageBox.Show("Record not inserted");
                MessageBox.Show(cat.ToString());
            }
        }

        

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE FROM Patients WHERE PId=@id", con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@id", numericUpDown1.Value);

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Dept = "I";
                /* Form f3 = new Form3();*/
            }
            else if (radioButton2.Checked == true)
            {
                Dept = "O";
                /*  Form f3 = new Form4(); */
            }
            else
            {
                MessageBox.Show("Select Department");
            }

            /*Gender*/
            if (radioButton3.Checked == true)
            {
                gender = "M";
            }
            else if (radioButton4.Checked == true)
            {
                gender = "F";
            }
            else
            {
                MessageBox.Show("Select Gender");
            }
            cmd = new SqlCommand("UPDATE Patients SET PName=@name,Age=@age,Phone=@phone,Doctor_ID=@did,Department=@Dept,Case_Id=@cid,Gender=@gen WHERE PId=@pid", con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@name", textBoxname.Text);
                cmd.Parameters.AddWithValue("@age", numericage.Value);
                cmd.Parameters.AddWithValue("@phone", long.Parse(textBoxphone.Text));
                cmd.Parameters.AddWithValue("@did",numericdid.Value);
                cmd.Parameters.AddWithValue("@Dept", Dept);
                cmd.Parameters.AddWithValue("@cid", numericUpDown3.Value);
                cmd.Parameters.AddWithValue("@gen", gender);
                cmd.Parameters.AddWithValue("@pid", numericUpDown1.Value);
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
