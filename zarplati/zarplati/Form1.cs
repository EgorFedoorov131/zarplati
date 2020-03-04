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

namespace zarplati
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=303-16; Initial Catalog=Zarplati; Integrated Security=true;");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From manager where Login_manager = '{textBox1.Text}' and Password = '{textBox2.Text}'", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                MessageBox.Show("заходи дружище");
                Form2 f = new Form2();
                f.id = Int32.Parse(dr[0].ToString());
               
                f.Show();
                this.Hide();
                dr.Close();
            }
            else
                MessageBox.Show("ты не наш");
            con.Close();
        }
    }
}
