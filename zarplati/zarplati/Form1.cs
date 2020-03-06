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
        // осуществляется подключение к базе данных под названием Zarplati
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From manager where Login_manager = '{textBox1.Text}' and Password = '{textBox2.Text}'", con);
            // происходит проверка логина и пароля по базе manager в столбцах Login_manager и пароль Password
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                MessageBox.Show("заходи дружище");
                // выводит окно при успешной автроизации
                Form2 f = new Form2();
                f.id = Int32.Parse(dr[0].ToString());
               
                f.Show();
                this.Hide();
                dr.Close();
            }
            else
                MessageBox.Show("ты не наш");
            //выводит окно при не успешной авторизации
            con.Close();
        }
    }
}
